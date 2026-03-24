using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output locations
        string inputPath = "sample.tif";
        string outputDirectory = "frames";

        // Verify input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the source image (could be multi‑page)
        using (Image image = Image.Load(inputPath))
        {
            // Determine if the image supports multiple pages/frames
            var multipage = image as IMultipageImage;
            int frameCount = multipage != null ? multipage.PageCount : 1;

            for (int i = 0; i < frameCount; i++)
            {
                // Retrieve the current page/frame as a raster image
                Image pageImage = multipage != null ? multipage.Pages[i] : image;

                // Create a TIFF frame from the raster image
                using (TiffFrame tiffFrame = new TiffFrame((RasterImage)pageImage))
                {
                    // Wrap the frame in a TIFF image container
                    using (TiffImage tiffImage = new TiffImage(tiffFrame))
                    {
                        // Build the output file path for this frame
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.tif");

                        // Ensure the directory for the output file exists (already created above)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the single‑frame TIFF image
                        tiffImage.Save(outputPath);
                    }
                }
            }
        }
    }
}