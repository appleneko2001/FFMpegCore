using FFMpegCore.Exceptions;
using Instances;

namespace FFMpegCore.Helpers
{
    public class FFProbeHelper
    {
        private static bool _ffprobeVerified;

        public static int Gcd(int first, int second)
        {
            while (first != 0 && second != 0)
            {
                if (first > second)
                    first -= second;
                else second -= first;
            }
            return first == 0 ? second : first;
        }

        public static void RootExceptionCheck()
        {
            if (GlobalFFOptions.Current.FFProbeBinaryPath == null)
                throw new FFOptionsException("FFProbe path is not configured. Missing key 'FFProbeBinaryPath'.");
        }
        
        public static void VerifyFFProbeExists(FFOptions ffMpegOptions)
        {
            if (_ffprobeVerified) return;
            var (exitCode, _) = Instance.Finish(GlobalFFOptions.GetFFProbeBinaryPath(ffMpegOptions), "-version");
            _ffprobeVerified = exitCode == 0;
            if (!_ffprobeVerified) 
                throw new FFProbeException("ffprobe was not found on your system");
        }
    }
}
