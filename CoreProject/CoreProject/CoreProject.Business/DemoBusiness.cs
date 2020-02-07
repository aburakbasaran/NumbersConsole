using CoreProject.BusinessContracts;
using CoreProject.DataLayerContracts;
using System;

namespace CoreProject.Business
{
    public class DemoBusiness:IDemoBusiness
    {
        private readonly IDemoDataLayer demoDataLayer;
        public DemoBusiness(IDemoDataLayer demoDataLayer)
        {
            this.demoDataLayer = demoDataLayer;
        }

        public void Deneme()
        {
            demoDataLayer.Deneme();
        }
    }
}
