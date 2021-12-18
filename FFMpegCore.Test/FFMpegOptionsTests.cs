using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;

namespace FFMpegCore.Test
{
    [TestClass]
    public class FFMpegOptionsTest
    {
        [TestMethod]
        public void Options_Initialized()
        {
            Assert.IsNotNull(GlobalFFOptions.Current);
        }

        [TestMethod]
        public void Options_Set_Programmatically()
        {
            var original = GlobalFFOptions.Current; 
            try
            {
                var v = "Whatever";
                
                GlobalFFOptions.Configure(new FFOptions { FFMpegBinaryPath = v, FFProbeBinaryPath = v});
                Assert.AreEqual(GlobalFFOptions.Current.FFMpegBinaryPath, v);
                Assert.AreEqual(GlobalFFOptions.Current.FFProbeBinaryPath, v);
            }
            finally
            {
                GlobalFFOptions.Configure(original);
            }
        }
    }
}
