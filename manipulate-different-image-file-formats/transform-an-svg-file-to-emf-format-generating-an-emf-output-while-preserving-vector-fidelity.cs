// Load the SVG image from file
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(@"C:\Images\input.svg"))
{
    // Configure vector rasterization options – set the page size to match the source image size
    Aspose.Imaging.ImageOptions.EmfRasterizationOptions rasterOptions = new Aspose.Imaging.ImageOptions.EmfRasterizationOptions
    {
        PageSize = image.Size
    };

    // Save the image as EMF using the configured options
    image.Save(@"C:\Images\output.emf", new Aspose.Imaging.ImageOptions.EmfOptions
    {
        VectorRasterizationOptions = rasterOptions
    });
}