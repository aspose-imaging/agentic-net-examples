using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

public class Program
{
    public static void Main(string[] args)
    {
        // Paths for input APNG and output filtered APNG
        string inputPath = "input.apng";
        string outputPath = "output_filtered.apng";

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access frames
            ApngImage apng = (ApngImage)image;

            // Apply deconvolution filter to each frame
            for (int i = 0; i < apng.PageCount; i++)
            {
                // Retrieve the frame and cast to RasterImage
                ApngFrame frame = (ApngFrame)apng.Pages[i];
                RasterImage raster = (RasterImage)frame;

                // Apply MotionWiener deconvolution filter (example parameters)
                raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));
            }

            // Save the modified APNG using ApngOptions
            ApngOptions saveOptions = new ApngOptions();
            image.Save(outputPath, saveOptions);
        }
    }
}