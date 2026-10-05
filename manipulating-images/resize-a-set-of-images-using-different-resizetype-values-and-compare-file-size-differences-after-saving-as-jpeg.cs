// HOW-TO: Resize Images with Different ResizeTypes and Compare JPEG File Sizes in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] inputFiles = Directory.GetFiles(inputDirectory);
            if (inputFiles.Length == 0)
            {
                Console.WriteLine("No input files found.");
                return;
            }

            List<ResizeType> resizeTypes = new List<ResizeType>
            {
                ResizeType.NearestNeighbourResample,
                ResizeType.LanczosResample
            };

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                foreach (ResizeType rtype in resizeTypes)
                {
                    using (Image image = Image.Load(inputPath))
                    {
                        int newWidth = Math.Max(1, image.Width / 2);
                        int newHeight = Math.Max(1, image.Height / 2);
                        image.Resize(newWidth, newHeight, rtype);

                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                        string outputPath = Path.Combine(outputDirectory, $"{fileNameWithoutExt}_{rtype}.jpg");

                        string outputDir = Path.GetDirectoryName(outputPath);
                        if (!string.IsNullOrEmpty(outputDir))
                        {
                            Directory.CreateDirectory(outputDir);
                        }

                        JpegOptions jpegOptions = new JpegOptions();
                        jpegOptions.Quality = 90;

                        image.Save(outputPath, jpegOptions);

                        long fileSize = new FileInfo(outputPath).Length;
                        Console.WriteLine($"Resized ({rtype}) {fileNameWithoutExt} -> {outputPath}, Size: {fileSize} bytes");
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
 * 1. When you need to generate smaller thumbnail versions of photos using various resampling algorithms and evaluate which algorithm yields the best balance of quality and file size.
 * 2. When you are building an automated batch‑processing pipeline that must downscale a collection of images and store them as JPEGs for web delivery.
 * 3. When you want to compare the compression efficiency of NearestNeighbourResample versus LanczosResample on the same image set before choosing a default resize method.
 * 4. When you have to ensure that resized images do not become zero‑pixel dimensions by enforcing a minimum width and height during the resize operation.
 * 5. When you need to programmatically create separate output files for each resize algorithm so you can analyze storage savings in a .NET application.
 */
