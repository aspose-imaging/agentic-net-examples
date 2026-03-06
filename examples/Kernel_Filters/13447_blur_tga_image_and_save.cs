// Path to the folder containing the source TGA image
string dataDir = @"c:\temp\";

// Load the TGA image using Aspose.Imaging's Image.Load method
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.tga"))
{
    // Cast the generic Image object to a TgaImage to access TGA‑specific functionality
    Aspose.Imaging.FileFormats.Tga.TgaImage tgaImage = (Aspose.Imaging.FileFormats.Tga.TgaImage)image;

    // Apply a Gaussian blur filter to the whole image.
    // Radius = 5, Sigma = 4.0 (same values used in the documentation examples)
    tgaImage.Filter(
        tgaImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image. Here we export it as PNG, but you could also save as TGA.
    tgaImage.Save(dataDir + "sample.GaussianBlur.png", new Aspose.Imaging.ImageOptions.PngOptions());
}