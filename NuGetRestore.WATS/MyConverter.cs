using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Virinco.WATS.Interface;


namespace MyNewConverter
{
    class MyConverter : IReportConverter_v2, IReportConverter
    {
        public Dictionary<string, string> ConverterParameters => throw new NotImplementedException();

        public void CleanUp()
        {
            //If needed, will be called if the WATS client service is stopped
        }

        ///
        /// This is the main interface call and the only thing you have to implement
        ///
        ///An open WATS TDM api (see own documentation)
        ///A file stream to a file placed in the drop folder defined by convertes.xml
        /// An UUT or UUR report (can also be null if desired, the conversion code must then handle submit
        public Report ImportReport(TDM api, System.IO.Stream file)
        {
            int lineCount = 0;
            try
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    /// Read file and send reports
                }
            }
            catch (Exception ex)
            {
                StreamWriter errorlog = new StreamWriter(api.ConversionSource.ErrorLog); //Will place the file in an error catalog
                errorlog.WriteLine("Error in file {0}, line {1}: {2}", api.ConversionSource.SourceFile.Name, lineCount, ex.Message);
                errorlog.Flush();
                throw;
            }
            return null;
        }
    }
}
