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
        // Hardcoded input paths
        string[] svgInputPaths = new[]
        {
            "input1.svg",
            "input2.svg"
        };

        // Hardcoded JSON configuration path
        string jsonConfigPath = "kernels.json";

        // Verify JSON configuration file exists
        if (!File.Exists(jsonConfigPath))
        {
            Console.Error.WriteLine($"File not found: {jsonConfigPath}");
            return;
        }

        // Load and parse kernel definitions (simple manual parsing)
        string json = File.ReadAllText(jsonConfigPath);
        List<(int Size, double Sigma)> kernels = new List<(int, double)>();
        int searchIndex = 0;
        while (true)
        {
            int sizeKeyIdx = json.IndexOf("\"Size\"", searchIndex, StringComparison.OrdinalIgnoreCase);
            if (sizeKeyIdx == -1) break;
            int colonIdx = json.IndexOf(':', sizeKeyIdx);
            int commaIdx = json.IndexOf(',', colonIdx);
            string sizeStr = json.Substring(colonIdx + 1, commaIdx - colonIdx - 1).Trim();
            int size = int.Parse(sizeStr);

            int sigmaKeyIdx = json.IndexOf("\"Sigma\"", commaIdx, StringComparison.OrdinalIgnoreCase);
            int colonSigmaIdx = json.IndexOf(':', sigmaKeyIdx);
            int endIdx = json.IndexOfAny(new char[] { ',', '}' }, colonSigmaIdx);
            string sigmaStr = json.Substring(colonSigmaIdx + 1, endIdx - colonSigmaIdx - 1).Trim();
            double sigma = double.Parse(sigmaStr, System.Globalization.CultureInfo.InvariantCulture);

            kernels.Add((size, sigma));
            searchIndex = endIdx;
        }

        // Process each SVG with each kernel
        foreach (string inputPath in svgInputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            for (int k = 0; k < kernels.Count; k++)
            {
                var (size, sigma) = kernels[k];

                // Define output file path
                string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_k{k + 1}.png";
                string outputPath = Path.Combine("output", outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Rasterize SVG to PNG in memory
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = svgImage.Size }
                    };

                    using (var memoryStream = new MemoryStream())
                    {
                        svgImage.Save(memoryStream, pngOptions);
                        memoryStream.Position = 0;

                        // Load rasterized image
                        using (Image rasterImg = Image.Load(memoryStream))
                        {
                            RasterImage rasterImage = (RasterImage)rasterImg;

                            // Apply sharpen filter with kernel from JSON
                            rasterImage.Filter(rasterImage.Bounds,
                                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(size, sigma));

                            // Save filtered image
                            rasterImage.Save(outputPath, new PngOptions());
                        }
                    }
                }
            }
        }
    }
}