using System;
using Google.Cloud.Speech.V1;
using System.Collections;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace SwearingIsFun.Library
{
    public class CloudInterface
    {
        private SpeechClient client;

        public CloudInterface()
        {
            Task.Run(async () => client = await SpeechClient.CreateAsync());
        }

        public async void GetTranscript(string uri, Action<string> callback)
        {
            if (client == null) return;
            var context = new SpeechContext() { Phrases = { File.ReadLines(CloudUtility.SwearList) } };
            var speechOperation = await client.LongRunningRecognizeAsync(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Flac,

                LanguageCode = "en-US",
                EnableWordTimeOffsets = true,
                SpeechContexts = { context }
            }, RecognitionAudio.FromFile(uri));

            speechOperation = await speechOperation.PollUntilCompletedAsync();
            var response = speechOperation.Result;
            string builder = "";
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    builder += alternative.Transcript;
                }
                builder += Environment.NewLine;
            }
            callback(builder);
        }
    }
}
