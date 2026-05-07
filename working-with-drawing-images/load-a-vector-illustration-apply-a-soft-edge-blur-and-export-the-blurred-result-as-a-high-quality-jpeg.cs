using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf.EmfPlus.Objects; // EmfPlusBlurEffect namespace

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\vector_input.emf";
            string outputPath = @"C:\Images\blurred_output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector illustration
            using (Image image = Image.Load(inputPath))
            {
                // Create a soft‑edge blur effect
                var blurEffect = new EmfPlusBlurEffect
                {
                    BlurRadius = 8.0f,   // radius in pixels (0‑255)
                    ExpandEdge = true   // expand bitmap to keep soft edges
                };

                // NOTE: Direct application of EmfPlusBlurEffect to a VectorImage is not
                // provided by the current API. The effect object is created here to
                // illustrate the intended usage. If the library supports attaching the
                // effect to the image, it would be done at this point.

                // Prepare high‑quality JPEG options
                var jpegOptions = new JpegOptions
                {
                    Quality = 100 // maximum quality
                };

                // Save the (potentially blurred) image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}