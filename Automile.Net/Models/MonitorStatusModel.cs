using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    /// <summary>
    /// PID001
    /// TODO: Not complete...
    /// </summary>
    public class MonitorStatusModel
    {
        private BitArray v;
        public TestStatus Misfire { get; private set; }
        public TestStatus FuelSystem { get; private set; }
        public TestStatus Components { get; private set; }
        public bool MIL { get; private set; }

        //A0-A6	DTC_CNT	Number of confirmed emissions-related DTCs available for display.
        public int ConfirmedEmissionsDtc { get; private set; }

        public MonitorStatusModel(Byte[] vB)
        {
            v = new BitArray(vB);

            DieselMIL dM;
            GasolineMIL gM;


            MIL = v[8];

            Misfire.TestAvailable = v[9];
            Misfire.TestInComplete = v[13];

            FuelSystem.TestAvailable = v[10];
            FuelSystem.TestInComplete = v[14];

            Components.TestAvailable = v[11];
            Components.TestInComplete = v[15];

            var isDiesel = v[11];

            if (isDiesel)
            {
                dM = new DieselMIL(v);
            }
            else
            {
                gM = new GasolineMIL(v);
            }
        }

        public bool FuelSystemMonitoringStatus { get; private set; }

        public class GasolineMIL
        {
            public TestStatus Catalyst { get; set; }
            public TestStatus HeatedCatalyst { get; set; }
            public TestStatus EvaporativeSystem { get; set; }
            public TestStatus SecondaryAirSystem { get; set; }
            public TestStatus A_C_Refrigerant { get; set; }
            public TestStatus OxygenSensor { get; set; }
            public TestStatus OxygenSensorHeater { get; set; }
            public TestStatus EGRSystem { get; set; }

            public GasolineMIL(BitArray v)
            {
                Catalyst.TestAvailable = v[17];
                Catalyst.TestInComplete = v[25];

                HeatedCatalyst.TestAvailable = v[18];
                HeatedCatalyst.TestInComplete = v[26];

                EvaporativeSystem.TestAvailable = v[19];
                EvaporativeSystem.TestInComplete = v[27];

                SecondaryAirSystem.TestAvailable = v[20];
                SecondaryAirSystem.TestInComplete = v[28];

                A_C_Refrigerant.TestAvailable = v[21];
                A_C_Refrigerant.TestInComplete = v[29];

                OxygenSensor.TestAvailable = v[22];
                OxygenSensor.TestInComplete = v[30];

                OxygenSensorHeater.TestAvailable = v[23];
                OxygenSensorHeater.TestInComplete = v[31];

                EGRSystem.TestAvailable = v[24];
                EGRSystem.TestInComplete = v[32];

            }
        }

        public class DieselMIL
        {
            public TestStatus NMHC_Cat { get; set; }
            public TestStatus NOx_SCR_Monitor { get; set; }
            public TestStatus Boost_Pressure { get; set; }
            public TestStatus Exhaust_Gas_Sensor { get; set; }
            public TestStatus PMFilterMonitoring { get; set; }
            public TestStatus EGRAndOrVVTSystem { get; set; }




            public DieselMIL(BitArray v)
            {

                NMHC_Cat.TestAvailable = v[17];
                NMHC_Cat.TestInComplete = v[25];

                NOx_SCR_Monitor.TestAvailable = v[18];
                NOx_SCR_Monitor.TestInComplete = v[26];

                Boost_Pressure.TestAvailable = v[20];
                Boost_Pressure.TestInComplete = v[28];

                Exhaust_Gas_Sensor.TestAvailable = v[22];
                Exhaust_Gas_Sensor.TestInComplete = v[30];

                PMFilterMonitoring.TestAvailable = v[23];
                PMFilterMonitoring.TestInComplete = v[31];

                EGRAndOrVVTSystem.TestAvailable = v[24];
                EGRAndOrVVTSystem.TestInComplete = v[32];
            }
        }

        public class TestStatus
        {
            public bool TestAvailable { get; set; }
            public bool TestInComplete { get; set; }
        }
    }
}
