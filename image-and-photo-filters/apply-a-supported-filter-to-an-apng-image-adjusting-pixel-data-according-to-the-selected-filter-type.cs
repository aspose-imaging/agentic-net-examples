using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class ApplyApngFilter
{
    static void Main()
    {
        // Path to the folder containing the APNG image.
        string dataDir = @"c:\temp\";

        // Load the APNG image from file.
        using (Image image = Image.Load(dataDir + "sample.apng"))
        {
            // Cast the generic Image to ApngImage to access the Filter method.
            ApngImage apngImage = (ApngImage)image;

            // Apply a median filter with a rectangle size of 5 to the entire image.
            // The Filter method takes a rectangle defining the area to process
            // and a FilterOptionsBase derived object specifying the filter type.
            apngImage.Filter(apngImage.Bounds, new MedianFilterOptions(5));

            // Save the filtered image back to disk (keeping the APNG format).
            apngImage.Save(dataDir + "sample.filtered.apng");
        }
    }
}