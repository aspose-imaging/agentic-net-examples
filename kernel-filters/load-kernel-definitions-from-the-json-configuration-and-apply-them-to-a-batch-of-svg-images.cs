// HOW-TO: Apply Custom Convolution Kernel from JSON to Multiple SVG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string configPath = "kernels.json";
            string[] svgFiles = new[]
            {
                "image1.svg",
                "image2.svg"
            };
            string outputFolder = "output";

            // Validate config file
            if (!File.Exists(configPath))
            {
                Console.Error.WriteLine($"File not found: {configPath}");
                return;
            }

            // Load kernel from JSON (expects format: {"kernel": [[a,b,c],[d,e,f],[g,h,i]]})
            string json = File.ReadAllText(configPath);
            int firstBracket = json.IndexOf('[');
            int lastBracket = json.LastIndexOf(']');
            if (firstBracket < 0 || lastBracket < 0 || lastBracket <= firstBracket)
            {
                Console.Error.WriteLine("Invalid kernel JSON format.");
                return;
            }
            string inner = json.Substring(firstBracket, lastBracket - firstBracket + 1);
            string[] rowStrings = inner.Trim('[', ']').Split(new string[] { "],[" }, StringSplitOptions.RemoveEmptyEntries);
            int size = rowStrings.Length;
            double[,] kernel = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                string row = rowStrings[i].Trim('[', ']');
                string[] values = row.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < size; j++)
                {
                    if (double.TryParse(values[j], out double val))
                    {
                        kernel[i, j] = val;
                    }
                    else
                    {
                        Console.Error.WriteLine("Invalid numeric value in kernel.");
                        return;
                    }
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            foreach (string svgPath in svgFiles)
            {
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);
                string tempPngPath = Path.Combine(outputFolder, fileNameWithoutExt + "_temp.png");
                string filteredPngPath = Path.Combine(outputFolder, fileNameWithoutExt + "_filtered.png");

                // Ensure directories for temp and filtered paths exist
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                Directory.CreateDirectory(Path.GetDirectoryName(filteredPngPath));

                // Load SVG and rasterize to temporary PNG
                using (Image svgImage = Image.Load(svgPath))
                {
                    var pngOptions = new PngOptions();
                    svgImage.Save(tempPngPath, pngOptions);
                }

                // Load rasterized PNG as RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(tempPngPath))
                {
                    // Apply convolution filter with custom kernel
                    var filterOptions = new ConvolutionFilterOptions(kernel);
                    rasterImage.Filter(rasterImage.Bounds, filterOptions);

                    // Save filtered image
                    var saveOptions = new PngOptions();
                    rasterImage.Save(filteredPngPath, saveOptions);
                }

                // Optionally delete temporary PNG
                try
                {
                    File.Delete(tempPngPath);
                }
                catch
                {
                    // Ignore deletion errors
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
 * 1. When you need to batch‑process a set of SVG graphics with a custom convolution filter defined in a JSON file, this code lets you load the kernel and apply it to each image.
 * 2. When a web application must dynamically sharpen or blur vector icons based on user‑provided parameters stored in JSON, the example shows how to read the kernel and process the SVGs in C#.
 * 3. When automating a CI pipeline that converts SVG assets to raster formats with a specific filter effect, you can use this code to read the kernel configuration and apply it before rendering.
 * 4. When integrating third‑party design tools that export filter settings as JSON, the snippet demonstrates how to import those settings and apply them to multiple SVG files using Aspose.Imaging.
 * 5. When creating a desktop utility that updates a library of SVG logos with a consistent emboss or edge‑detect effect defined in a JSON kernel, this example provides the necessary loading and batch‑application logic.
 */
