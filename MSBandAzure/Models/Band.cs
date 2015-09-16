using Microsoft.Band;
using MSBandAzure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MSBandAzure.Model
{
    public class Band
    {
        private IBandInfo _info;
        private IBandClient _bandClient;

        public Band(IBandInfo info)
        {
            _info = info;
        }
        public string Name { get { return _info.Name; } }

        public bool Connected { get; set; }

        public async Task Connect()
        {
            _bandClient = await BandClientManager.Instance.ConnectAsync(_info);

            // Note. The following code is a workaround for a bug in the Band SDK;
            // see the following link 
            // http://stackoverflow.com/questions/30611731/microsoft-band-sdk-sensors-windows-sample-exception
            Type.GetType("Microsoft.Band.BandClient, Microsoft.Band")
                        .GetRuntimeFields()
                        .First(field => field.Name == "currentAppId")
                        .SetValue(_bandClient, Guid.NewGuid());

            SensorData = new List<DataViewModelBase>
                    {
                        new HeartRateViewModel(_bandClient),
                    };

            Connected = true;
        }

        public List<DataViewModelBase> SensorData { get; set; }
    }
}