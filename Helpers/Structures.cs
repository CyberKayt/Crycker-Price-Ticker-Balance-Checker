namespace DaddyRecoveryBuilder.Helpers
{
    using System;
    using System.Runtime.InteropServices;

    public static class Structures
    {
        [StructLayout(LayoutKind.Sequential)]
        public partial struct ICONDIR
        {
            public ushort Reserved;
            public ushort Type;
            public ushort Count;
        }

        [StructLayout(LayoutKind.Sequential)]
        public partial struct ICONDIRENTRY
        {
            public byte Width;
            public byte Height;
            public byte ColorCount;
            public byte Reserved;
            public ushort Planes;
            public ushort BitCount;
            public int BytesInRes;
            public int ImageOffset;
        }

        /// <summary>
        /// A resource header.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct RESOURCE_HEADER
        {
            /// <summary>
            /// Header length.
            /// </summary>
            public ushort wLength;
            /// <summary>
            /// Data length.
            /// </summary>
            public ushort wValueLength;
            /// <summary>
            /// Resource type.
            /// </summary>
            public ushort wType;

            /// <summary>
            /// A new resource header of a given length.
            /// </summary>
            /// <param name="valueLength"></param>
            public RESOURCE_HEADER(ushort valueLength)
            {
                wLength = 0;
                wValueLength = valueLength;
                wType = 0;
            }
        }

        /// <summary>
        /// Language and code page combinations.
        /// The low-order word of each DWORD must contain a Microsoft language identifier, 
        /// and the high-order word must contain the IBM code page number. 
        /// Either high-order or low-order word can be zero, indicating that the file is language 
        /// or code page independent.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct VAR_HEADER
        {
            /// <summary>
            /// Microsoft language identifier.
            /// </summary>
            public ushort wLanguageIDMS;
            /// <summary>
            /// IBM code page number.
            /// </summary>
            public ushort wCodePageIBM;
        }

        /// <summary>
        /// This structure contains version information about a file. 
        /// This information is language- and code page–independent.
        /// http://msdn.microsoft.com/en-us/library/ms647001.aspx
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct VS_FIXEDFILEINFO
        {
            /// <summary>
            /// Contains the value 0xFEEF04BD. This is used with the szKey member of the VS_VERSIONINFO structure when searching a file for the VS_FIXEDFILEINFO structure. 
            /// </summary>
            public uint dwSignature;
            /// <summary>
            /// Specifies the binary version number of this structure. The high-order word of this member contains the major version number, and the low-order word contains the minor version number.
            /// </summary>
            public uint dwStrucVersion;
            /// <summary>
            /// Specifies the most significant 32 bits of the file's binary version number. This member is used with dwFileVersionLS to form a 64-bit value used for numeric comparisons.
            /// </summary>
            public uint dwFileVersionMS;
            /// <summary>
            /// Specifies the least significant 32 bits of the file's binary version number. This member is used with dwFileVersionMS to form a 64-bit value used for numeric comparisons.
            /// </summary>
            public uint dwFileVersionLS;
            /// <summary>
            /// Specifies the most significant 32 bits of the binary version number of the product with which this file was distributed. This member is used with dwProductVersionLS to form a 64-bit value used for numeric comparisons.
            /// </summary>
            public uint dwProductVersionMS;
            /// <summary>
            /// Specifies the least significant 32 bits of the binary version number of the product with which this file was distributed. This member is used with dwProductVersionMS to form a 64-bit value used for numeric comparisons.
            /// </summary>
            public uint dwProductVersionLS;
            /// <summary>
            /// Contains a bitmask that specifies the valid bits in dwFileFlags. A bit is valid only if it was defined when the file was created. 
            /// </summary>
            public uint dwFileFlagsMask;
            /// <summary>
            /// Contains a bitmask that specifies the Boolean attributes of the file.
            /// </summary>
            public uint dwFileFlags;
            /// <summary>
            /// Specifies the operating system for which this file was designed.
            /// </summary>
            public uint dwFileOS;
            /// <summary>
            /// Specifies the general type of file. 
            /// </summary>
            public uint dwFileType;
            /// <summary>
            /// Specifies the function of the file.
            /// </summary>
            public uint dwFileSubtype;
            /// <summary>
            /// Specifies the most significant 32 bits of the file's 64-bit binary creation date and time stamp.
            /// </summary>
            public uint dwFileDateMS;
            /// <summary>
            /// Specifies the least significant 32 bits of the file's 64-bit binary creation date and time stamp.
            /// </summary>
            public uint dwFileDateLS;

            /// <summary>
            /// Creates a default Windows VS_FIXEDFILEINFO structure.
            /// </summary>
            /// <returns>A default Windows VS_FIXEDFILEINFO.</returns>
            public static VS_FIXEDFILEINFO GetWindowsDefault()
            {
                var fixedFileInfo = new VS_FIXEDFILEINFO
                {
                    dwSignature = NativeMethods.VS_FFI_SIGNATURE,
                    dwStrucVersion = NativeMethods.VS_FFI_STRUCVERSION,
                    dwFileFlagsMask = NativeMethods.VS_FFI_FILEFLAGSMASK,
                    dwFileOS = (uint)Enums.FileOs.VOS__WINDOWS32,
                    dwFileSubtype = (uint)Enums.FileSubType.VFT2_UNKNOWN,
                    dwFileType = (uint)Enums.FileType.VFT_DLL
                };
                return fixedFileInfo;
            }
        }

        /// <summary>
        /// A hardware-independent icon directory resource header.
        /// http://msdn.microsoft.com/en-us/library/ms997538.aspx
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct GRPICONDIR
        {
            /// <summary>
            /// Reserved, must be zero.
            /// </summary>
            public ushort wReserved;
            /// <summary>
            /// Resource type, 1 for icons.
            /// </summary>
            public ushort wType;
            /// <summary>
            /// Number of images.
            /// </summary>
            public ushort wImageCount;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public partial struct GRPICONDIRENTRY
        {
            public byte Width;
            public byte Height;
            public byte ColorCount;
            public byte Reserved;
            public ushort Planes;
            public ushort BitCount;
            public int BytesInRes;
            public ushort ID;
        }

        /// <summary>
        /// Hardware-independent icon directory entry in an .ico file.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct FILEGRPICONDIRENTRY
        {
            /// <summary>
            /// Icon width.
            /// </summary>
            public byte bWidth;
            /// <summary>
            /// Icon height.
            /// </summary>
            public byte bHeight;
            /// <summary>
            /// Colors; 0 means 256 or more.
            /// </summary>
            public byte bColors;
            /// <summary>
            /// Reserved.
            /// </summary>
            public byte bReserved;
            /// <summary>
            /// Number of bitmap planes for icons.
            /// Horizontal hotspot for cursors.
            /// </summary>
            public ushort wPlanes;
            /// <summary>
            /// Bits per pixel for icons.
            /// Vertical hostpot for cursors.
            /// </summary>
            public ushort wBitsPerPixel;
            /// <summary>
            /// Image size in bytes.
            /// </summary>
            public uint dwImageSize;
            /// <summary>
            /// Offset of bitmap data from the beginning of the file.
            /// </summary>
            public uint dwFileOffset;
        }

        /// <summary>
        /// Hardware-independent icon structure in an .ico file.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct FILEGRPICONDIR
        {
            /// <summary>
            /// Reserved, must be zero.
            /// </summary>
            public ushort wReserved;
            /// <summary>
            /// Resource Type (1 for icons).
            /// </summary>
            public ushort wType;
            /// <summary>
            /// Number of images.
            /// </summary>
            public ushort wCount;
        }

        /// <summary>
        /// Contains information about an icon or a cursor. 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct ICONINFO
        {
            /// <summary>
            /// Specifies whether this structure defines an icon or a cursor. 
            /// A value of TRUE specifies an icon; FALSE specifies a cursor. 
            /// </summary>
            public bool IsIcon;
            /// <summary>
            /// Specifies the x-coordinate of a cursor's hot spot. If this structure defines an icon, the hot spot is 
            /// always in the center of the icon, and this member is ignored.
            /// </summary>
            public int xHotspot;
            /// <summary>
            /// Specifies the y-coordinate of the cursor's hot spot. If this structure defines an icon, the hot spot 
            /// is always in the center of the icon, and this member is ignored.
            /// </summary>
            public int yHotspot;
            /// <summary>
            /// Specifies the icon bitmask bitmap. 
            /// </summary>
            public IntPtr MaskBitmap;
            /// <summary>
            /// Handle to the icon color bitmap.
            /// </summary>
            public IntPtr ColorBitmap;
        }

        [StructLayout(LayoutKind.Sequential)]
        public partial struct BITMAPINFOHEADER
        {
            public uint Size;
            public int Width;
            public int Height;
            public ushort Planes;
            public ushort BitCount;
            public uint Compression;
            public uint SizeImage;
            public int XPelsPerMeter;
            public int YPelsPerMeter;
            public uint ClrUsed;
            public uint ClrImportant;
        }

        /// <summary>
        /// Defines the dimensions and color information of a Windows-based device-independent bitmap (DIB). 
        /// http://msdn.microsoft.com/en-us/library/dd183375(VS.85).aspx.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFO
        {
            /// <summary>
            /// Specifies a bitmap information header structure that contains information about the dimensions of color format.
            /// </summary>
            public BITMAPINFOHEADER bmiHeader;
            /// <summary>
            /// An array of RGBQUAD. The elements of the array make up the color table.
            /// </summary>
            public RGBQUAD bmiColors;
        }

        /// <summary>
        /// Store colors in a paletised icon (2, 4 or 8 bit).
        /// http://msdn.microsoft.com/en-us/library/ms997538.aspx
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RGBQUAD
        {
            /// <summary>
            /// Blue.
            /// </summary>
            public byte rgbBlue;
            /// <summary>
            /// Green.
            /// </summary>
            public byte rgbGreen;
            /// <summary>
            /// Red.
            /// </summary>
            public byte rgbRed;
            /// <summary>
            /// Reserved.
            /// </summary>
            public byte rgbReserved;
        }

        /// <summary>
        /// The BITMAPFILEHEADER structure contains information about the type, size, and layout of a file that contains a DIB.
        /// http://msdn.microsoft.com/en-us/library/dd183374(VS.85).aspx
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct BITMAPFILEHEADER
        {
            /// <summary>
            /// The file type; must be BM.
            /// </summary>
            public ushort bfType;
            /// <summary>
            /// The size, in bytes, of the bitmap file.
            /// </summary>
            public uint bfSize;
            /// <summary>
            /// Reserved; must be zero.
            /// </summary>
            public ushort bfReserved1;
            /// <summary>
            /// Reserved; must be zero.
            /// </summary>
            public ushort bfReserved2;
            /// <summary>
            /// The offset, in bytes, from the beginning of the BITMAPFILEHEADER structure to the bitmap bits.
            /// </summary>
            public uint bfOffBits;
        }
    }
}