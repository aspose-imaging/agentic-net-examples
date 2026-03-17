using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.webp";
        string outputPath = "output_resized.webp";

        // Configure load options with a modest buffer size to limit memory allocations
        LoadOptions loadOptions = new LoadOptions
        {
            BufferSizeHint = 4 * 1024 * 1024 // 4 MB buffer
        };

        // Open the input WebP file as a stream to avoid loading the whole file into memory at once
        using (FileStream inputStream = File.OpenRead(inputPath))
        // Load the WebP image using the stream and the configured load options
        using (WebPImage webpImage = new WebPImage(inputStream, loadOptions))
        {
            // Determine new dimensions (e.g., reduce size by 50%)
            int newWidth = webpImage.Width / 2;
            int newHeight = webpImage.Height / 2;

            // Perform a memory‑efficient resize using nearest‑neighbour resampling
            webpImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Prepare save options with a buffer hint and desired compression settings
            WebPOptions saveOptions = new WebPOptions
            {
                BufferSizeHint = 4 * 1024 * 1024, // match load buffer size
                Lossless = false,
                Quality = 80
            };

            // Save the processed image directly to the output stream
            using (FileStream outputStream = File.OpenWrite(outputPath))
            {
                webpImage.Save(outputStream, saveOptions);
            }
        }
    }
}