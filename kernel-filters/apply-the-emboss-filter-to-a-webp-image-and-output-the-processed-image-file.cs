using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Input WebP file and output PNG file paths
        string inputPath = "input.webp";
        string outputPath = "output_emboss.png";

        // Load the WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WebPImage to access WebP-specific methods
            WebPImage webpImage = (WebPImage)image;

            // Apply the emboss filter to the entire image
            webpImage.Filter(webpImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image as PNG
            webpImage.Save(outputPath, new PngOptions());
        }
    }
}