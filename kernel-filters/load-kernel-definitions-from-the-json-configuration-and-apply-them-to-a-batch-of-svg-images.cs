// HOW-TO: Apply JSON Defined Convolution Kernel to Multiple SVG Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputSvgs";
            string outputDirectory = "OutputSvgs";
            string configPath = "kernels.json";

            if (!File.Exists(configPath))
            {
                Console.Error.WriteLine($"File not found: {configPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            // Parse kernel matrix from JSON (simple numeric extraction)
            string json = File.ReadAllText(configPath);
            List<double> numbers = new List<double>();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            bool inNumber = false;
            foreach (char c in json)
            {
                if (char.IsDigit(c) || c == '-' || c == '.' || c == 'e' || c == 'E')
                {
                    sb.Append(c);
                    inNumber = true;
                }
                else
                {
                    if (inNumber)
                    {
                        if (double.TryParse(sb.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double val))
                        {
                            numbers.Add(val);
                        }
                        sb.Clear();
                        inNumber = false;
                    }
                }
            }
            if (inNumber && sb.Length > 0)
            {
                if (double.TryParse(sb.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double val))
                {
                    numbers.Add(val);
                }
            }

            if (numbers.Count == 0)
            {
                Console.Error.WriteLine("No kernel data found in configuration.");
                return;
            }

            int size = (int)Math.Sqrt(numbers.Count);
            if (size * size != numbers.Count)
            {
                Console.Error.WriteLine("Kernel matrix is not square.");
                return;
            }

            double[,] kernel = new double[size, size];
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] = numbers[index++];
                }
            }

            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");
            foreach (string inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + "_filtered.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load SVG and rasterize to temporary PNG
                string tempPng = Path.Combine(outputDirectory, Guid.NewGuid().ToString() + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPng));

                using (Image svgImage = Image.Load(inputPath))
                {
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions();
                    svgImage.Save(tempPng, pngOptions);
                }

                // Load raster image, apply convolution filter, and save result
                using (RasterImage raster = (RasterImage)Image.Load(tempPng))
                {
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, filterOptions);
                    raster.Save(outputPath);
                }

                // Clean up temporary file
                if (File.Exists(tempPng))
                {
                    File.Delete(tempPng);
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
 * 1. When you need to batch‑process SVG icons with a custom blur or sharpen filter defined in a JSON kernel file using Aspose.Imaging for .NET.
 * 2. When you want to automate the application of a user‑provided convolution matrix to a collection of vector graphics before converting them to raster formats.
 * 3. When a graphics pipeline requires loading filter parameters from a configuration file and applying the same effect to every SVG asset in a folder.
 * 4. When you are building a CI/CD step that validates visual consistency by applying a predefined kernel to all SVG diagrams stored in source control.
 * 5. When you need to read numeric kernel values from a JSON file and programmatically apply the filter to multiple SVG images without manual editing.
 */
