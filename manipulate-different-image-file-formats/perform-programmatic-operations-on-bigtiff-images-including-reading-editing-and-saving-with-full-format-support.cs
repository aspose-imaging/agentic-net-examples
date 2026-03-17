using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

namespace BigTiffProcessingDemo
{
    class Program
    {
        static void Main()
        {
            // Path to the source BigTIFF file
            const string inputPath = @"C:\Images\source_big.tif";

            // Path where the edited BigTIFF will be saved
            const string outputPath = @"C:\Images\edited_big.tif";

            // Load the BigTIFF image using Aspose.Imaging's built‑in loader.
            // The returned Image is cast to BigTiffImage to access BigTIFF‑specific members.
            using (BigTiffImage bigTiff = (BigTiffImage)Image.Load(inputPath))
            {
                // -----------------------------------------------------------------
                // Example edit 1: Adjust brightness (+30)
                // -----------------------------------------------------------------
                bigTiff.AdjustBrightness(30);

                // -----------------------------------------------------------------
                // Example edit 2: Rotate the image 45 degrees around its centre
                // -----------------------------------------------------------------
                bigTiff.Rotate(45f);

                // -----------------------------------------------------------------
                // Example edit 3: Resize the image to 50% of its original dimensions
                // -----------------------------------------------------------------
                int newWidth = bigTiff.Width / 2;
                int newHeight = bigTiff.Height / 2;
                bigTiff.Resize(newWidth, newHeight);

                // -----------------------------------------------------------------
                // Save the modified image back to disk.
                // The Save(string) overload handles format detection automatically.
                // -----------------------------------------------------------------
                bigTiff.Save(outputPath);
            }

            Console.WriteLine("BigTIFF processing completed successfully.");
        }
    }
}