using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] jpgFiles = new[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // List to hold generated EMZ file paths
        var emzFiles = new System.Collections.Generic.List<string>();

        // Process each JPG: verify, convert to EMZ
        foreach (string jpgPath in jpgFiles)
        {
            // Input file existence check
            if (!File.Exists(jpgPath))
            {
                Console.Error.WriteLine($"File not found: {jpgPath}");
                return;
            }

            // Define EMZ output path (same folder, .emz extension)
            string emzPath = jpgPath + ".emz";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(emzPath));

            // Load JPG, convert and save as compressed EMZ
            using (Image image = Image.Load(jpgPath))
            {
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                var emfOptions = new EmfOptions
                {
                    VectorRasterizationOptions = vectorOptions,
                    Compress = true
                };

                image.Save(emzPath, emfOptions);
            }

            emzFiles.Add(emzPath);
        }

        // Verify that at least one EMZ file was created
        if (emzFiles.Count == 0)
        {
            Console.Error.WriteLine("No EMZ files were generated.");
            return;
        }

        // Create a multipage image from the EMZ files
        Image pdfSource = Image.Create(emzFiles.ToArray());

        // Define PDF output path
        string outputPdf = @"C:\Output\CombinedImages.pdf";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdf));

        // Save the multipage image as a PDF document
        pdfSource.Save(outputPdf, new PdfOptions());

        // Clean up
        pdfSource.Dispose();

        Console.WriteLine($"PDF created successfully at: {outputPdf}");
    }
}