using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // List of image files to process
            string[] files = new[] { "image1.jpg", "image2.png", "image3.bmp" };

            // Resize types to compare
            ResizeType[] resizeTypes = new[]
            {
                ResizeType.NearestNeighbourResample,
                ResizeType.BilinearResample,
                ResizeType.LanczosResample,
                ResizeType.HighQualityResample,
                ResizeType.CatmullRom
            };

            foreach (string fileName in files)
            {
                string inputPath = Path.Combine(inputDir, fileName);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                foreach (ResizeType resizeType in resizeTypes)
                {
                    // Load the original image for each resize operation
                    using (Image image = Image.Load(inputPath))
                    {
                        // Example: resize to half of original dimensions
                        int newWidth = image.Width / 2;
                        int newHeight = image.Height / 2;

                        // Perform resizing with the specified ResizeType
                        image.Resize(newWidth, newHeight, resizeType);

                        // Prepare output path (JPEG format)
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{resizeType}.jpg";
                        string outputPath = Path.Combine(outputDir, outputFileName);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save as JPEG
                        image.Save(outputPath, new JpegOptions());

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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate thumbnail previews of user‑uploaded JPEG, PNG, or BMP files and compare how different ResizeType algorithms affect the resulting JPEG file size.
 * 2. When an e‑commerce platform must batch‑process product images to half their dimensions while evaluating which resampling method (NearestNeighbour, Bilinear, Lanczos, HighQuality, CatmullRom) yields the smallest JPEG payload for faster page loads.
 * 3. When a mobile app backend wants to resize photos taken on various devices and store them as JPEG, using Aspose.Imaging’s ResizeType options to determine the best trade‑off between visual quality and storage cost.
 * 4. When a digital asset management system needs to create multiple versions of the same image with different resampling filters and compare the compression ratios after saving as JPEG to choose the optimal preset.
 * 5. When a developer is benchmarking Aspose.Imaging’s C# image processing performance by resizing a set of images with each ResizeType and measuring the resulting JPEG file size differences for reporting or optimization purposes.
 */