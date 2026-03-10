using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

string dataDir = @"c:\temp\";

// Load the APNG image
using (Image image = Image.Load(dataDir + "sample.apng"))
{
    // Cast to ApngImage to access APNG‑specific members
    ApngImage apngImage = (ApngImage)image;

    // Iterate through each frame (page) of the APNG
    foreach (ApngFrame frame in apngImage.Pages)
    {
        // Apply a Gaussian blur filter to the whole frame
        // Rectangle covering the entire frame + filter options (radius 5, sigma 4.0)
        frame.Filter(frame.Bounds, new GaussianBlurFilterOptions(5, 4.0));
    }

    // Save the modified APNG back to disk
    apngImage.Save(dataDir + "sample.filtered.apng");
}