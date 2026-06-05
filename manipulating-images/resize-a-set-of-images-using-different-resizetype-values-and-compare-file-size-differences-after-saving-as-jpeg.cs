using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input image paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg"
            };

            // Resize types to compare
            ResizeType[] resizeTypes = new ResizeType[]
            {
                ResizeType.NearestNeighbourResample,
                ResizeType.BilinearResample,
                ResizeType.LanczosResample,
                ResizeType.HighQualityResample
            };

            // Target dimensions
            int newWidth = 800;
            int newHeight = 600;

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                foreach (ResizeType resizeType in resizeTypes)
                {
                    // Load the image fresh for each resize operation
                    using (Image image = Image.Load(inputPath))
                    {
                        // Perform resizing with the specified ResizeType
                        image.Resize(newWidth, newHeight, resizeType);

                        // Build output path: output\<filename>_<ResizeType>.jpg
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                        string outputPath = Path.Combine("output", $"{fileNameWithoutExt}_{resizeType}.jpg");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // JPEG save options
                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = 90 // reasonable quality for size comparison
                        };

                        // Save the resized image as JPEG
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