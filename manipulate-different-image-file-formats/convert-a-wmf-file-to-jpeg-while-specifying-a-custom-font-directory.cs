using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CustomFontHandler;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected errors
        try
        {
            // Hard‑coded input WMF, output JPEG and custom font folder paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample.jpg";
            string fontFolder = @"C:\CustomFonts";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare load options with a custom font source
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(GetFontSource, fontFolder);

            // Load the WMF image using the custom font settings
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Set JPEG specific options (defaults are sufficient here)
                var jpegOptions = new JpegOptions();

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Custom font provider – reads all font files from the supplied folder
    private static CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = string.Empty;
        if (args.Length > 0)
        {
            fontsPath = args[0].ToString();
        }

        var fonts = new System.Collections.Generic.List<CustomFontData>();
        foreach (var file in Directory.GetFiles(fontsPath))
        {
            fonts.Add(new CustomFontData(
                Path.GetFileNameWithoutExtension(file),
                File.ReadAllBytes(file)));
        }
        return fonts.ToArray();
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop publishing system needs to render legacy WMF vector graphics that use proprietary fonts into web‑friendly JPEG thumbnails, developers can use this code to load the WMF with a custom font directory and save it as JPEG.
 * 2. When an automated report generator must embed WMF charts that rely on corporate typefaces into email attachments, the snippet lets the application locate the required fonts and convert the charts to JPEG for universal viewing.
 * 3. When a migration tool processes a batch of old Windows Metafile files stored on a file server and must produce JPEG previews while preserving the exact appearance of text using fonts stored in a separate network folder, this code provides the necessary conversion logic.
 * 4. When a document management system receives user‑uploaded WMF logos that reference custom brand fonts, developers can employ this example to load the WMF with those fonts from a designated folder and output a JPEG version for indexing and preview.
 * 5. When a C# batch job needs to generate low‑resolution JPEG snapshots of WMF diagrams for mobile devices, and the diagrams use fonts not installed on the server, the code shows how to point Aspose.Imaging to a custom font path and perform the conversion.
 */