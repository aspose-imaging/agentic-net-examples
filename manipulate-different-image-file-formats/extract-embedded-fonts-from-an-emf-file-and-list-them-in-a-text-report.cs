// HOW-TO: Extract Embedded Fonts from EMF and Generate Text Report in C# (Aspose.Imaging for .NET)
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EmfFontExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputPath = "input.emf";
                string outputPath = "fonts_report.txt";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                // Read EMF file bytes
                byte[] data = File.ReadAllBytes(inputPath);
                int index = 0;
                var fonts = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                const uint EMR_CREATEFONTINDIRECTW = 0x2D; // 45

                while (index + 8 <= data.Length)
                {
                    uint type = BitConverter.ToUInt32(data, index);
                    uint size = BitConverter.ToUInt32(data, index + 4);

                    if (size == 0 || index + size > data.Length)
                    {
                        // Corrupt record, break to avoid infinite loop
                        break;
                    }

                    if (type == EMR_CREATEFONTINDIRECTW && size >= 92 + 8)
                    {
                        // Face name starts at offset 36 from record start
                        int faceOffset = index + 36;
                        if (faceOffset + 64 <= data.Length)
                        {
                            string faceName = Encoding.Unicode.GetString(data, faceOffset, 64);
                            int nullPos = faceName.IndexOf('\0');
                            if (nullPos >= 0)
                                faceName = faceName.Substring(0, nullPos);
                            if (!string.IsNullOrWhiteSpace(faceName))
                                fonts.Add(faceName);
                        }
                    }

                    index += (int)size;
                }

                // Write report
                var lines = new List<string>();
                lines.Add("Embedded Fonts Report");
                lines.Add("=====================");
                foreach (var font in fonts)
                {
                    lines.Add(font);
                }

                File.WriteAllLines(outputPath, lines, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to audit which fonts are embedded in a Windows Metafile (EMF) to verify licensing compliance.
 * 2. When converting legacy EMF drawings to PDF and must list the fonts to ensure proper embedding.
 * 3. When building a document‑processing pipeline that validates that all fonts referenced in EMF files are available on the target system.
 * 4. When generating a summary of fonts used across multiple EMF assets for a design review or asset inventory.
 * 5. When troubleshooting rendering problems in EMF files by extracting and examining the embedded font names.
 */
