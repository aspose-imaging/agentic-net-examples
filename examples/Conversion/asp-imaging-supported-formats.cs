using System;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Retrieve the registered formats for loading, creating, and exporting images
        FileFormat loadFormats = ImageLoadersRegistry.RegisteredFormats;
        FileFormat createFormats = ImageCreatorsRegistry.RegisteredFormats;
        FileFormat exportFormats = ImageExportersRegistry.RegisteredFormats;

        Console.WriteLine("Supported Load Formats:");
        PrintSupportedFormats(loadFormats);

        Console.WriteLine("\nSupported Create Formats:");
        PrintSupportedFormats(createFormats);

        Console.WriteLine("\nSupported Export Formats:");
        PrintSupportedFormats(exportFormats);
    }

    // Helper method to enumerate and display the individual formats contained in a FileFormat flag
    static void PrintSupportedFormats(FileFormat formats)
    {
        foreach (FileFormat format in Enum.GetValues(typeof(FileFormat)))
        {
            // Skip the undefined entry
            if (format == FileFormat.Unknown) continue;

            // Check if the current flag is present in the combined format value
            if (formats.HasFlag(format))
            {
                Console.WriteLine($"- {format}");
            }
        }
    }
}