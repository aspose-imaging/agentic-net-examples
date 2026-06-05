using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define relative input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory; create if missing and exit
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            // Path for the conversion report
            string reportPath = Path.Combine(outputDirectory, "report.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            // Open report writer
            using (var reportWriter = new StreamWriter(reportPath, false))
            {
                foreach (var inputPath in files)
                {
                    // Verify the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Determine output APNG path
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".apng");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    try
                    {
                        // Load the source PNG as a raster image
                        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
                        {
                            // Configure APNG creation options
                            using (ApngOptions createOptions = new ApngOptions
                            {
                                Source = new FileCreateSource(outputPath, false),
                                DefaultFrameTime = 100, // 100 ms per frame
                                ColorType = PngColorType.TruecolorWithAlpha
                            })
                            {
                                // Create the APNG image bound to the output file
                                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
                                {
                                    // Remove the default single frame
                                    apngImage.RemoveAllFrames();

                                    // Add the source image as the only frame
                                    apngImage.AddFrame(sourceImage);

                                    // Save the APNG (output path already bound via FileCreateSource)
                                    apngImage.Save();
                                }
                            }
                        }

                        // Log success to the report
                        reportWriter.WriteLine($"Success: {inputPath} -> {outputPath}");
                    }
                    catch (Exception ex)
                    {
                        // Log failure to the report
                        reportWriter.WriteLine($"Failed: {inputPath} -> {outputPath} : {ex.Message}");
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