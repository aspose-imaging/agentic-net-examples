using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputPath = "input.svg";
        // Desired EMF output file path
        string outputPath = "output.emf";

        // Load the SVG image using Aspose.Imaging.Image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Set up vector rasterization options for EMF conversion
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size // Preserve original dimensions
            };

            // Configure EMF save options and assign rasterization settings
            using (EmfOptions emfOptions = new EmfOptions())
            {
                emfOptions.VectorRasterizationOptions = rasterOptions;
                // Save the image as EMF, preserving vector fidelity
                image.Save(outputPath, emfOptions);
            }
        }
    }
}