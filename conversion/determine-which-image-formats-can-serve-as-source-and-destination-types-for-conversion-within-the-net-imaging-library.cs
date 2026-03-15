using System;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Retrieve the formats that can be loaded (source formats)
        FileFormat sourceFormats = ImageLoadersRegistry.RegisteredFormats;

        // Retrieve the formats that can be exported/saved (destination formats)
        FileFormat destinationFormats = ImageExportersRegistry.RegisteredFormats;

        Console.WriteLine("Supported source (loadable) formats:");
        foreach (FileFormat fmt in Enum.GetValues(typeof(FileFormat)))
        {
            // The FileFormat enum is flagged, so we can test each flag with a bitwise AND
            if ((sourceFormats & fmt) != 0)
            {
                Console.WriteLine($"- {fmt}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Supported destination (exportable) formats:");
        foreach (FileFormat fmt in Enum.GetValues(typeof(FileFormat)))
        {
            if ((destinationFormats & fmt) != 0)
            {
                Console.WriteLine($"- {fmt}");
            }
        }
    }
}