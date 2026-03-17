using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ApngInMemoryExample
{
    static void Main()
    {
        // Load a source image (single or multi‑page) from disk
        using (Image sourceImage = Image.Load("source.png"))
        {
            // Configure APNG options – e.g., set default frame duration to 200 ms
            var apngOptions = new ApngOptions
            {
                DefaultFrameTime = 200 // milliseconds
            };

            // Prepare an in‑memory stream to receive the encoded APNG data
            using (var memoryStream = new MemoryStream())
            {
                // Save the image to the stream using the APNG options
                sourceImage.Save(memoryStream, apngOptions);

                // At this point the stream contains the APNG bytes.
                // Optionally, retrieve the byte array for further processing.
                byte[] apngData = memoryStream.ToArray();

                // Example: write the APNG data to a file (for verification)
                File.WriteAllBytes("output.apng", apngData);
            }
        }
    }
}