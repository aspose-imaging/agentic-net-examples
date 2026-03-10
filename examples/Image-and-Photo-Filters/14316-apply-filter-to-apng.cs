using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class ApplyApngFilter
{
    static void Main()
    {
        // Paths to the source APNG and the destination file
        string sourcePath = "input.apng";
        string destinationPath = "output.apng";

        // Load the APNG image using the standard Image.Load method (lifecycle rule)
        using (Image image = Image.Load(sourcePath))
        {
            // Cast the loaded image to ApngImage to access APNG‑specific members
            ApngImage apngImage = (ApngImage)image;

            // Apply a Gaussian blur filter to the whole image.
            // The Filter method is defined for ApngImage (member rule).
            // Rectangle covering the entire image is obtained via apngImage.Bounds.
            // GaussianBlurFilterOptions(radius, sigma) creates the filter options.
            apngImage.Filter(apngImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the modified APNG using the Save method with ApngOptions (lifecycle rule).
            // This preserves the animation frames while writing the result.
            apngImage.Save(destinationPath, new ApngOptions());
        }
    }
}