// HOW-TO: Compare JPEG File Sizes Using Different Resize Types in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded list of input image files (relative paths)
            string[] inputFiles = { "input1.jpg", "input2.png", "input3.bmp" };

            // Resize types to compare
            ResizeType[] resizeTypes = {
                ResizeType.NearestNeighbourResample,
                ResizeType.LanczosResample,
                ResizeType.BilinearResample
            };

            // Process each input file
            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Process each resize type for the current image
                foreach (ResizeType resizeType in resizeTypes)
                {
                    // Load the image (wrapped in using for proper disposal)
                    using (Image image = Image.Load(inputPath))
                    {
                        // Example scaling factor: reduce size to 50%
                        int newWidth = image.Width / 2;
                        int newHeight = image.Height / 2;

                        // Perform resizing with the selected ResizeType
                        image.Resize(newWidth, newHeight, resizeType);

                        // Build output file path
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                        string outputDir = "Output";
                        string outputFileName = $"{fileNameWithoutExt}_{resizeType}.jpg";
                        string outputPath = Path.Combine(outputDir, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save as JPEG using default options
                        var jpegOptions = new JpegOptions();
                        image.Save(outputPath, jpegOptions);

                        // Report file size
                        long fileSize = new FileInfo(outputPath).Length;
                        Console.WriteLine($"{outputPath}: {fileSize} bytes");
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

/*
 * Real-World Use Cases:
 * 1. When you need to generate smaller thumbnail versions of a batch of photos and want to see which Aspose.Imaging ResizeType (NearestNeighbour, Lanczos, Bilinear) yields the smallest JPEG file size.
 * 2. When optimizing images for web delivery and you must compare how different resampling algorithms affect visual quality versus compressed JPEG size in a C# application.
 * 3. When building an automated image processing pipeline that converts various source formats (JPG, PNG, BMP) to JPEG and you need to evaluate the impact of each ResizeType on storage savings.
 * 4. When performing A/B testing of image resizing strategies to choose the best trade‑off between processing speed and JPEG compression results in a .NET service.
 * 5. When creating a report of file size differences after resizing images with Aspose.Imaging, to help stakeholders decide which resampling method to adopt for a mobile app.
 */
