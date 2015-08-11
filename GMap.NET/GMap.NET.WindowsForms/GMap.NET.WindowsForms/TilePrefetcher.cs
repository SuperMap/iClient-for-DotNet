﻿
namespace GMap.NET
{
   using System.Collections.Generic;
   using System.ComponentModel;
   using System.Windows.Forms;
   using GMap.NET.Internals;
   using System;
   using GMap.NET.MapProviders;
   using System.Threading;

   /// <summary>
   /// form helping to prefetch tiles on local db
   /// </summary>
   public partial class TilePrefetcher : Form
   {
      BackgroundWorker worker = new BackgroundWorker();
      List<GPoint> list;
      int zoom;
      GMapProvider provider;
      int sleep;
      int all;
      public bool ShowCompleteMessage = false;
      RectLatLng area;
      GMap.NET.GSize maxOfTiles;

      public TilePrefetcher()
      {
         InitializeComponent();

         GMaps.Instance.OnTileCacheComplete += new TileCacheComplete(OnTileCacheComplete);
         GMaps.Instance.OnTileCacheStart += new TileCacheStart(OnTileCacheStart);
         GMaps.Instance.OnTileCacheProgress += new TileCacheProgress(OnTileCacheProgress);

         worker.WorkerReportsProgress = true;
         worker.WorkerSupportsCancellation = true;
         worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
         worker.DoWork += new DoWorkEventHandler(worker_DoWork);
         worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
      }

      readonly AutoResetEvent done = new AutoResetEvent(true);

      void OnTileCacheComplete()
      {
         if(!IsDisposed)
         {
            done.Set();

            MethodInvoker m = delegate
            {
               label2.Text = "all tiles saved";
            };
            Invoke(m);
         }
      }

      void OnTileCacheStart()
      {
         if(!IsDisposed)
         {
            done.Reset();

            MethodInvoker m = delegate
            {
               label2.Text = "saving tiles...";
            };
            Invoke(m);
         }
      }

      void OnTileCacheProgress(int left)
      {
         if(!IsDisposed)
         {
            MethodInvoker m = delegate
            {
               label2.Text = left + " tile to save...";
            };
            Invoke(m);
         }
      }

      public void Start(RectLatLng area, int zoom, GMapProvider provider, int sleep)
      {
         if(!worker.IsBusy)
         {
            this.label1.Text = "...";
            this.progressBarDownload.Value = 0;

            this.area = area;
            this.zoom = zoom;
            this.provider = provider;
            this.sleep = sleep;

            GMaps.Instance.UseMemoryCache = false;
            GMaps.Instance.CacheOnIdleRead = false;
            GMaps.Instance.BoostCacheEngine = true;

            worker.RunWorkerAsync();

            this.ShowDialog();
         }
      }

      public void Stop()
      {
         GMaps.Instance.OnTileCacheComplete -= new TileCacheComplete(OnTileCacheComplete);
         GMaps.Instance.OnTileCacheStart -= new TileCacheStart(OnTileCacheStart);
         GMaps.Instance.OnTileCacheProgress -= new TileCacheProgress(OnTileCacheProgress);

         done.Set();

         if(worker.IsBusy)
         {
            worker.CancelAsync();
         }

         GMaps.Instance.CancelTileCaching();

         done.Close();
      }

      void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if(ShowCompleteMessage)
         {
            if(!e.Cancelled)
            {
               MessageBox.Show("Prefetch Complete! => " + ((int)e.Result).ToString() + " of " + all);
            }
            else
            {
               MessageBox.Show("Prefetch Canceled! => " + ((int)e.Result).ToString() + " of " + all);
            }
         }

         list.Clear();

         GMaps.Instance.UseMemoryCache = true;
         GMaps.Instance.CacheOnIdleRead = true;
         GMaps.Instance.BoostCacheEngine = false;

         this.Close();
      }

      bool CacheTiles(int zoom, GPoint p)
      {
         foreach(var pr in provider.Overlays)
         {
            Exception ex;
            PureImage img;

            // tile number inversion(BottomLeft -> TopLeft) for pergo maps
            if(pr is TurkeyMapProvider)
            {
               img = GMaps.Instance.GetImageFrom(pr, new GPoint(p.X, maxOfTiles.Height - p.Y), zoom, out ex);
            }
            else // ok
            {
               img = GMaps.Instance.GetImageFrom(pr, p, zoom, out ex);
            }

            if(img != null)
            {
               img.Dispose();
               img = null;
            }
            else
            {
               return false;
            }
         }
         return true;
      }

      void worker_DoWork(object sender, DoWorkEventArgs e)
      {
         if(list != null)
         {
            list.Clear();
            list = null;
         }
         list = provider.Projection.GetAreaTileList(area, zoom, 0);
         maxOfTiles = provider.Projection.GetTileMatrixMaxXY(zoom);
         all = list.Count;

         int countOk = 0;
         int retry = 0;

         Stuff.Shuffle<GPoint>(list);

         for(int i = 0; i < all; i++)
         {
            if(worker.CancellationPending)
               break;

            GPoint p = list[i];
            {
               if(CacheTiles(zoom, p))
               {
                  countOk++;
                  retry = 0;
               }
               else
               {
                  if(++retry <= 1) // retry only one
                  {
                     i--;
                     System.Threading.Thread.Sleep(1111);
                     continue;
                  }
                  else
                  {
                     retry = 0;
                  }
               }
            }

            worker.ReportProgress((int)((i + 1) * 100 / all), i + 1);

            System.Threading.Thread.Sleep(sleep);
         }

         e.Result = countOk;

         if(!IsDisposed)
         {
            done.WaitOne();
         }
      }

      void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         this.label1.Text = "Fetching tile at zoom (" + zoom + "): " + ((int)e.UserState).ToString() + " of " + all + ", complete: " + e.ProgressPercentage.ToString() + "%";
         this.progressBarDownload.Value = e.ProgressPercentage;
      }

      private void Prefetch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
      {
         if(e.KeyCode == Keys.Escape)
         {
            this.Close();
         }
      }

      private void Prefetch_FormClosed(object sender, FormClosedEventArgs e)
      {
         this.Stop();
      }
   }
}
