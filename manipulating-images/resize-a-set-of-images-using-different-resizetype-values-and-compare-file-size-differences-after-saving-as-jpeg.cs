using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageResizeComparison
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDir = @"C:\Images\Input\";
                string outputDir = @"C:\Images\Output\";

                // List of images to process
                string[] inputFiles = { "sample1.jpg", "sample2.png" };

                // Resize types to compare
                ResizeType[] resizeTypes = {
                    ResizeType.NearestNeighbourResample,
                    ResizeType.BilinearResample,
                    ResizeType.LanczosResample,
                    ResizeType.HighQualityResample,
                    ResizeType.CatmullRom
                };

                foreach (var fileName in inputFiles)
                {
                    string inputPath = Path.Combine(inputDir, fileName);

                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    foreach (var rtype in resizeTypes)
                    {
                        // Load the original image for each resize type
                        using (var image = Image.Load(inputPath))
                        {
                            // Desired dimensions
                            int newWidth = 200;
                            int newHeight = 200;

                            // Perform resizing with the specific ResizeType
                            image.Resize(newWidth, newHeight, rtype);

                            // Build output file name and path
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{rtype}.jpg";
                            string outputPath = Path.Combine(outputDir, outputFileName);

                            // Ensure output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save as JPEG
                            var jpegOptions = new JpegOptions();
                            image.Save(outputPath, jpegOptions);

                            // Report file size
                            long fileSize = new FileInfo(outputPath).Length;
                            Console.WriteLine($"{outputFileName}: {fileSize} bytes");
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
}