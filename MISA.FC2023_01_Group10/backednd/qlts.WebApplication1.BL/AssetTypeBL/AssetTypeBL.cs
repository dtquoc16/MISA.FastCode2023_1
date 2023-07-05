using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL.AssetTypeDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.BL.AssetTypeBL
{
    public class AssetTypeBL : BaseBL<AssetType>, IAssetTypeBL
    {
        #region Field

        private IAssetTypeDL _assetTypeDL;

        #endregion

        #region Constructor

        public AssetTypeBL(IAssetTypeDL assetTypeDL) : base(assetTypeDL)
        {
            _assetTypeDL = assetTypeDL;
        }
        #endregion
    }
}
