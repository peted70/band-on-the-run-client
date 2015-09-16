using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSBandAzure.Model;
using Microsoft.Band;

namespace MSBandAzure.Services
{
    public class MSBandService : IBandService
    {
        public async Task<IEnumerable<Band>> GetPairedBands()
        {
            IBandInfo[] pairedBands = await BandClientManager.Instance.GetBandsAsync();
            return pairedBands.Select(i => new Band(i)).ToList();
        }
    }
}
