using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.cdr");
        string outputPath = Path.Combine("Output", "sample.jpg");

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load CDR file into a memory stream
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                // Load CDR image from the memory stream
                LoadOptions loadOptions = new LoadOptions();
                using (CdrImage cdrImage = new CdrImage(memoryStream, loadOptions))
                {
                    // Prepare JPEG options with vector rasterization settings
                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        jpegOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = cdrImage.Width,
                            PageHeight = cdrImage.Height
                        };

                        // Save directly to JPEG without intermediate files
                        cdrImage.Save(outputPath, jpegOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}