using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.DEMO.Web04.DTQUOC.BL.AssetTypeBL;
using MISA.QLTS.DEMO.Web04.DTQUOC.Common.Entity;

namespace MISA.QLTS.DEMO.Web04.DTQUOC.API.Controllers
{
    public class AssetTypeController : BaseController<AssetType>
    {
        #region Field

        private IAssetTypeBL  _assetTypeBL;

        #endregion

        #region Constructor

        public AssetTypeController (IAssetTypeBL assetTypeBL) : base(assetTypeBL)
        {
            _assetTypeBL= assetTypeBL;
        }
        #endregion
    }
}
