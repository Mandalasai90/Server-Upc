using Urban.BAL.Requests;
using UrbanPoshAPIApp.Controllers;

namespace UrbanPoshAPIApp.Repository.UPCMaster
{
    public class UPCMastersRepo
    {
        private readonly ILogger<UPCMastersRepo> _logger;
        public UPCMastersRepo(ILogger<UPCMastersRepo> logger) {

            _logger = logger;
        }

        public  async Task<IEnumerable<>> UPCLogin(LoginRequest loginRequest)
        {
            try
            {

            }
            catch (Exception ex) {
                _logger.LogError("UPCMastersRepo:Method-UPCLogin:" + ex.Message.ToString());
            }
        }
    }
}
