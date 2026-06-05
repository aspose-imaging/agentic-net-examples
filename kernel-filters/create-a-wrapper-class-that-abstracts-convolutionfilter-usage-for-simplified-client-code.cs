using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

public class ConvolutionFilterWrapper
{
    public FilterOptionsBase Options { get; }

    public ConvolutionFilterWrapper(string filterName)
    {
        switch (filterName)
        {
            case "Emboss":
                Options = new ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3,
                    1.0,
                    0);
                break;
            case "Sharpen":
                Options = new ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen3x3,
                    1.0,
                    0);
                break;
            case "BoxBlur":
                Options = new ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(3),
                    1.0,
                    0);
                break;
            default:
                throw new NotSupportedException($"Filter '{filterName}' is not supported.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                var wrapper = new ConvolutionFilterWrapper("Emboss");
                raster.Filter(raster.Bounds, wrapper.Options);
                raster.Save(outputPath);
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
 * 1. When a developer needs to apply an emboss effect to user‑uploaded PNG photos in a .NET web application without writing repetitive convolution code.
 * 2. When a batch‑processing tool must sharpen a collection of JPEG images before they are indexed for search, using Aspose.Imaging’s ConvolutionFilterWrapper to simplify the filter call.
 * 3. When an automated document‑generation service creates thumbnail previews of scanned PDFs and wants to add a subtle box‑blur to reduce noise, the wrapper abstracts the 3×3 blur kernel.
 * 4. When a desktop C# utility allows end‑users to select a filter name from a dropdown (e.g., “Emboss”, “Sharpen”, “BoxBlur”) and instantly applies it to BMP files, the wrapper maps the name to the correct ConvolutionFilterOptions.
 * 5. When a CI/CD pipeline runs integration tests that verify image‑processing algorithms, the wrapper provides a concise way to instantiate and apply standard convolution filters across multiple image formats.
 */