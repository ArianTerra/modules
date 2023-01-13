namespace ORM.Models.Enums;

/// <summary>
/// Gender Types by ISO 5218
/// <para>See https://en.wikipedia.org/wiki/ISO/IEC_5218</para>
/// </summary>
public enum Gender : byte
{
    NotKnown = 0,
    Male = 1,
    Female = 2,
    NotApplicable = 9
}