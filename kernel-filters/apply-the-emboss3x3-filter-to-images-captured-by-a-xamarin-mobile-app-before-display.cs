using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                PngOptions options = new PngOptions();
                rasterImage.Save(outputPath, options);
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
 * 1. When a Xamarin mobile app needs to display user‑taken photos with a stylized 3‑D look, a developer can load the PNG, apply the Emboss3x3 convolution filter, and save the result for immediate rendering.
 * 2. When generating thumbnail previews for a gallery view, applying the Emboss3x3 filter in C# creates a distinctive embossed effect that helps users quickly identify images.
 * 3. When preparing images for print‑ready PDFs, developers can emboss PNG assets using Aspose.Imaging to add depth before embedding them in the document.
 * 4. When creating custom UI icons or buttons that require a raised appearance, the Emboss3x3 filter can be applied to the source PNG files during the app’s asset pipeline.
 * 5. When a social‑sharing feature must apply a consistent artistic filter to all uploaded pictures, the code can process each image on the server side with the Emboss3x3 convolution before sending it back to the Xamarin client.
 */