using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
#if !WINDOWS_PHONE
    internal class LabelMatrixCellConverter : CustomCreationConverter<LabelMatrixCell>
#else
    public class LabelMatrixCellConverter : CustomCreationConverter<LabelMatrixCell>
#endif
    {
        public override LabelMatrixCell Create(Type objectType)
        {
            if (typeof(LabelImageCell) == objectType)
            {
                return new LabelImageCell();
            }
            else if (typeof(LabelSymbolCell) == objectType)
            {
                return new LabelSymbolCell();
            }
            else if (typeof(LabelThemeCell) == objectType)
            {
                return new LabelThemeCell();
            }
            throw new NotImplementedException();
        }
    }
}
