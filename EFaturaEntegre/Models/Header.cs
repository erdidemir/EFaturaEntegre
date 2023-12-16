// using System.Xml.Serialization;
// XmlSerializer serializer = new XmlSerializer(typeof(StandardBusinessDocument));
// using (StringReader reader = new StringReader(xml))
// {
//    var test = (StandardBusinessDocument)serializer.Deserialize(reader);
// }

using System.Xml.Serialization;

[XmlRoot(ElementName = "ContactInformation")]
public class ContactInformation
{

    [XmlElement(ElementName = "Contact")]
    public string Contact { get; set; }

    [XmlElement(ElementName = "ContactTypeIdentifier")]
    public string ContactTypeIdentifier { get; set; }
}

[XmlRoot(ElementName = "Sender")]
public class Sender
{

    [XmlElement(ElementName = "Identifier")]
    public string Identifier { get; set; }

    [XmlElement(ElementName = "ContactInformation")]
    public List<ContactInformation> ContactInformation { get; set; }
}

[XmlRoot(ElementName = "Receiver")]
public class Receiver
{

    [XmlElement(ElementName = "Identifier")]
    public string Identifier { get; set; }

    [XmlElement(ElementName = "ContactInformation")]
    public List<ContactInformation> ContactInformation { get; set; }
}

[XmlRoot(ElementName = "DocumentIdentification")]
public class DocumentIdentification
{

    [XmlElement(ElementName = "Standard")]
    public object Standard { get; set; }

    [XmlElement(ElementName = "TypeVersion")]
    public double TypeVersion { get; set; }

    [XmlElement(ElementName = "InstanceIdentifier")]
    public string InstanceIdentifier { get; set; }

    [XmlElement(ElementName = "Type")]
    public string Type { get; set; }

    [XmlElement(ElementName = "CreationDateAndTime")]
    public DateTime CreationDateAndTime { get; set; }
}

[XmlRoot(ElementName = "StandardBusinessDocumentHeader")]
public class StandardBusinessDocumentHeader
{

    [XmlElement(ElementName = "HeaderVersion")]
    public double HeaderVersion { get; set; }

    [XmlElement(ElementName = "Sender")]
    public Sender Sender { get; set; }

    [XmlElement(ElementName = "Receiver")]
    public Receiver Receiver { get; set; }

    [XmlElement(ElementName = "DocumentIdentification")]
    public DocumentIdentification DocumentIdentification { get; set; }
}

[XmlRoot(ElementName = "CanonicalizationMethod")]
public class CanonicalizationMethod
{

    [XmlAttribute(AttributeName = "Algorithm")]
    public string Algorithm { get; set; }
}

[XmlRoot(ElementName = "SignatureMethod")]
public class SignatureMethod
{

    [XmlAttribute(AttributeName = "Algorithm")]
    public string Algorithm { get; set; }
}

[XmlRoot(ElementName = "Transform")]
public class Transform
{

    [XmlAttribute(AttributeName = "Algorithm")]
    public string Algorithm { get; set; }
}

[XmlRoot(ElementName = "Transforms")]
public class Transforms
{

    [XmlElement(ElementName = "Transform")]
    public Transform Transform { get; set; }
}

[XmlRoot(ElementName = "DigestMethod")]
public class DigestMethod
{

    [XmlAttribute(AttributeName = "Algorithm")]
    public string Algorithm { get; set; }
}

[XmlRoot(ElementName = "Reference")]
public class Reference
{

    [XmlElement(ElementName = "Transforms")]
    public Transforms Transforms { get; set; }

    [XmlElement(ElementName = "DigestMethod")]
    public DigestMethod DigestMethod { get; set; }

    [XmlElement(ElementName = "DigestValue")]
    public string DigestValue { get; set; }

    [XmlAttribute(AttributeName = "URI")]
    public object URI { get; set; }

    [XmlText]
    public string Text { get; set; }

    [XmlAttribute(AttributeName = "Id")]
    public string Id { get; set; }

    [XmlAttribute(AttributeName = "Type")]
    public string Type { get; set; }
}

[XmlRoot(ElementName = "SignedInfo")]
public class SignedInfo
{

    [XmlElement(ElementName = "CanonicalizationMethod")]
    public CanonicalizationMethod CanonicalizationMethod { get; set; }

    [XmlElement(ElementName = "SignatureMethod")]
    public SignatureMethod SignatureMethod { get; set; }

    [XmlElement(ElementName = "Reference")]
    public List<Reference> Reference { get; set; }

    [XmlAttribute(AttributeName = "Id")]
    public string Id { get; set; }

    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "SignatureValue")]
public class SignatureValue
{

    [XmlAttribute(AttributeName = "Id")]
    public string Id { get; set; }

    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "RSAKeyValue")]
public class RSAKeyValue
{

    [XmlElement(ElementName = "Modulus")]
    public string Modulus { get; set; }

    [XmlElement(ElementName = "Exponent")]
    public string Exponent { get; set; }
}

[XmlRoot(ElementName = "KeyValue")]
public class KeyValue
{

    [XmlElement(ElementName = "RSAKeyValue")]
    public RSAKeyValue RSAKeyValue { get; set; }
}

[XmlRoot(ElementName = "X509Data")]
public class X509Data
{

    [XmlElement(ElementName = "X509SubjectName")]
    public string X509SubjectName { get; set; }

    [XmlElement(ElementName = "X509Certificate")]
    public string X509Certificate { get; set; }
}

[XmlRoot(ElementName = "KeyInfo")]
public class KeyInfo
{

    [XmlElement(ElementName = "KeyValue")]
    public KeyValue KeyValue { get; set; }

    [XmlElement(ElementName = "X509Data")]
    public X509Data X509Data { get; set; }
}

[XmlRoot(ElementName = "CertDigest")]
public class CertDigest
{

    [XmlElement(ElementName = "DigestMethod")]
    public DigestMethod DigestMethod { get; set; }

    [XmlElement(ElementName = "DigestValue")]
    public string DigestValue { get; set; }
}

[XmlRoot(ElementName = "IssuerSerial")]
public class IssuerSerial
{

    [XmlElement(ElementName = "X509IssuerName")]
    public string X509IssuerName { get; set; }

    [XmlElement(ElementName = "X509SerialNumber")]
    public double X509SerialNumber { get; set; }
}

[XmlRoot(ElementName = "Cert")]
public class Cert
{

    [XmlElement(ElementName = "CertDigest")]
    public CertDigest CertDigest { get; set; }

    [XmlElement(ElementName = "IssuerSerial")]
    public IssuerSerial IssuerSerial { get; set; }
}

[XmlRoot(ElementName = "SigningCertificate")]
public class SigningCertificate
{

    [XmlElement(ElementName = "Cert")]
    public Cert Cert { get; set; }
}

[XmlRoot(ElementName = "ClaimedRoles")]
public class ClaimedRoles
{

    [XmlElement(ElementName = "ClaimedRole")]
    public string ClaimedRole { get; set; }
}

[XmlRoot(ElementName = "SignerRole")]
public class SignerRole
{

    [XmlElement(ElementName = "ClaimedRoles")]
    public ClaimedRoles ClaimedRoles { get; set; }
}

[XmlRoot(ElementName = "SignedSignatureProperties")]
public class SignedSignatureProperties
{

    [XmlElement(ElementName = "SigningTime")]
    public DateTime SigningTime { get; set; }

    [XmlElement(ElementName = "SigningCertificate")]
    public SigningCertificate SigningCertificate { get; set; }

    [XmlElement(ElementName = "SignerRole")]
    public SignerRole SignerRole { get; set; }
}

[XmlRoot(ElementName = "SignedProperties")]
public class SignedProperties
{

    [XmlElement(ElementName = "SignedSignatureProperties")]
    public SignedSignatureProperties SignedSignatureProperties { get; set; }

    [XmlAttribute(AttributeName = "Id")]
    public string Id { get; set; }

    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "QualifyingProperties")]
public class QualifyingProperties
{

    [XmlElement(ElementName = "SignedProperties")]
    public SignedProperties SignedProperties { get; set; }

    [XmlAttribute(AttributeName = "Target")]
    public string Target { get; set; }

    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "Object")]
public class Object
{

    [XmlElement(ElementName = "QualifyingProperties")]
    public QualifyingProperties QualifyingProperties { get; set; }
}

[XmlRoot(ElementName = "Signature")]
public class Signature
{

    [XmlElement(ElementName = "SignedInfo")]
    public SignedInfo SignedInfo { get; set; }

    [XmlElement(ElementName = "SignatureValue")]
    public SignatureValue SignatureValue { get; set; }

    [XmlElement(ElementName = "KeyInfo")]
    public KeyInfo KeyInfo { get; set; }

    [XmlElement(ElementName = "Object")]
    public Object Object { get; set; }

    [XmlAttribute(AttributeName = "Id")]
    public string Id { get; set; }

    [XmlText]
    public string Text { get; set; }

    [XmlElement(ElementName = "ID")]
    public ID ID { get; set; }

    [XmlElement(ElementName = "SignatoryParty")]
    public SignatoryParty SignatoryParty { get; set; }

    [XmlElement(ElementName = "DigitalSignatureAttachment")]
    public DigitalSignatureAttachment DigitalSignatureAttachment { get; set; }
}

[XmlRoot(ElementName = "ExtensionContent")]
public class ExtensionContent
{

    [XmlElement(ElementName = "Signature")]
    public Signature Signature { get; set; }
}

[XmlRoot(ElementName = "UBLExtension")]
public class UBLExtension
{

    [XmlElement(ElementName = "ExtensionContent")]
    public ExtensionContent ExtensionContent { get; set; }
}

[XmlRoot(ElementName = "UBLExtensions")]
public class UBLExtensions
{

    [XmlElement(ElementName = "UBLExtension")]
    public UBLExtension UBLExtension { get; set; }
}

[XmlRoot(ElementName = "DocumentCurrencyCode")]
public class DocumentCurrencyCode
{

    [XmlAttribute(AttributeName = "listAgencyName")]
    public string ListAgencyName { get; set; }

    [XmlAttribute(AttributeName = "listID")]
    public string ListID { get; set; }

    [XmlAttribute(AttributeName = "listName")]
    public string ListName { get; set; }

    [XmlAttribute(AttributeName = "listVersionID")]
    public int ListVersionID { get; set; }

    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "EmbeddedDocumentBinaryObject")]
public class EmbeddedDocumentBinaryObject
{

    [XmlAttribute(AttributeName = "characterSetCode")]
    public string CharacterSetCode { get; set; }

    [XmlAttribute(AttributeName = "encodingCode")]
    public string EncodingCode { get; set; }

    [XmlAttribute(AttributeName = "filename")]
    public string Filename { get; set; }

    [XmlAttribute(AttributeName = "mimeCode")]
    public string MimeCode { get; set; }

    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "Attachment")]
public class Attachment
{

    [XmlElement(ElementName = "EmbeddedDocumentBinaryObject")]
    public EmbeddedDocumentBinaryObject EmbeddedDocumentBinaryObject { get; set; }
}

[XmlRoot(ElementName = "AdditionalDocumentReference")]
public class AdditionalDocumentReference
{

    [XmlElement(ElementName = "ID")]
    public string ID { get; set; }

    [XmlElement(ElementName = "IssueDate")]
    public DateTime IssueDate { get; set; }

    [XmlElement(ElementName = "Attachment")]
    public Attachment Attachment { get; set; }
}

[XmlRoot(ElementName = "ID")]
public class ID
{

    [XmlAttribute(AttributeName = "schemeID")]
    public string SchemeID { get; set; }

    [XmlText]
    public double Text { get; set; }
}

[XmlRoot(ElementName = "PartyIdentification")]
public class PartyIdentification
{

    [XmlElement(ElementName = "ID")]
    public ID ID { get; set; }
}

[XmlRoot(ElementName = "Country")]
public class Country
{

    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }
}

[XmlRoot(ElementName = "PostalAddress")]
public class PostalAddress
{

    [XmlElement(ElementName = "Room")]
    public int Room { get; set; }

    [XmlElement(ElementName = "StreetName")]
    public string StreetName { get; set; }

    [XmlElement(ElementName = "BuildingName")]
    public string BuildingName { get; set; }

    [XmlElement(ElementName = "BuildingNumber")]
    public int BuildingNumber { get; set; }

    [XmlElement(ElementName = "CitySubdivisionName")]
    public string CitySubdivisionName { get; set; }

    [XmlElement(ElementName = "CityName")]
    public string CityName { get; set; }

    [XmlElement(ElementName = "PostalZone")]
    public int PostalZone { get; set; }

    [XmlElement(ElementName = "Region")]
    public string Region { get; set; }

    [XmlElement(ElementName = "Country")]
    public Country Country { get; set; }
}

[XmlRoot(ElementName = "SignatoryParty")]
public class SignatoryParty
{

    [XmlElement(ElementName = "PartyIdentification")]
    public PartyIdentification PartyIdentification { get; set; }

    [XmlElement(ElementName = "PostalAddress")]
    public PostalAddress PostalAddress { get; set; }
}

[XmlRoot(ElementName = "ExternalReference")]
public class ExternalReference
{

    [XmlElement(ElementName = "URI")]
    public string URI { get; set; }
}

[XmlRoot(ElementName = "DigitalSignatureAttachment")]
public class DigitalSignatureAttachment
{

    [XmlElement(ElementName = "ExternalReference")]
    public ExternalReference ExternalReference { get; set; }
}

[XmlRoot(ElementName = "PartyName")]
public class PartyName
{

    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }
}

[XmlRoot(ElementName = "TaxScheme")]
public class TaxScheme
{

    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    [XmlElement(ElementName = "TaxTypeCode")]
    public int TaxTypeCode { get; set; }
}

[XmlRoot(ElementName = "PartyTaxScheme")]
public class PartyTaxScheme
{

    [XmlElement(ElementName = "TaxScheme")]
    public TaxScheme TaxScheme { get; set; }
}

[XmlRoot(ElementName = "Contact")]
public class Contact
{

    [XmlElement(ElementName = "Telephone")]
    public double Telephone { get; set; }

    [XmlElement(ElementName = "Telefax")]
    public double Telefax { get; set; }

    [XmlElement(ElementName = "ElectronicMail")]
    public string ElectronicMail { get; set; }
}

[XmlRoot(ElementName = "Party")]
public class Party
{

    [XmlElement(ElementName = "PartyIdentification")]
    public PartyIdentification PartyIdentification { get; set; }

    [XmlElement(ElementName = "PartyName")]
    public PartyName PartyName { get; set; }

    [XmlElement(ElementName = "PostalAddress")]
    public PostalAddress PostalAddress { get; set; }

    [XmlElement(ElementName = "PartyTaxScheme")]
    public PartyTaxScheme PartyTaxScheme { get; set; }

    [XmlElement(ElementName = "Contact")]
    public Contact Contact { get; set; }
}

[XmlRoot(ElementName = "AccountingSupplierParty")]
public class AccountingSupplierParty
{

    [XmlElement(ElementName = "Party")]
    public Party Party { get; set; }
}

[XmlRoot(ElementName = "AccountingCustomerParty")]
public class AccountingCustomerParty
{

    [XmlElement(ElementName = "Party")]
    public Party Party { get; set; }
}

[XmlRoot(ElementName = "TaxAmount")]
public class TaxAmount
{

    [XmlAttribute(AttributeName = "currencyID")]
    public string CurrencyID { get; set; }

    [XmlText]
    public double Text { get; set; }
}

[XmlRoot(ElementName = "TaxableAmount")]
public class TaxableAmount
{

    [XmlAttribute(AttributeName = "currencyID")]
    public string CurrencyID { get; set; }

    [XmlText]
    public double Text { get; set; }
}

[XmlRoot(ElementName = "TaxCategory")]
public class TaxCategory
{

    [XmlElement(ElementName = "TaxScheme")]
    public TaxScheme TaxScheme { get; set; }
}

[XmlRoot(ElementName = "TaxSubtotal")]
public class TaxSubtotal
{

    [XmlElement(ElementName = "TaxableAmount")]
    public TaxableAmount TaxableAmount { get; set; }

    [XmlElement(ElementName = "TaxAmount")]
    public TaxAmount TaxAmount { get; set; }

    [XmlElement(ElementName = "CalculationSequenceNumeric")]
    public int CalculationSequenceNumeric { get; set; }

    [XmlElement(ElementName = "Percent")]
    public int Percent { get; set; }

    [XmlElement(ElementName = "TaxCategory")]
    public TaxCategory TaxCategory { get; set; }
}

[XmlRoot(ElementName = "TaxTotal")]
public class TaxTotal
{

    [XmlElement(ElementName = "TaxAmount")]
    public TaxAmount TaxAmount { get; set; }

    [XmlElement(ElementName = "TaxSubtotal")]
    public TaxSubtotal TaxSubtotal { get; set; }
}

[XmlRoot(ElementName = "LineExtensionAmount")]
public class LineExtensionAmount
{

    [XmlAttribute(AttributeName = "currencyID")]
    public string CurrencyID { get; set; }

    [XmlText]
    public double Text { get; set; }
}

[XmlRoot(ElementName = "TaxExclusiveAmount")]
public class TaxExclusiveAmount
{

    [XmlAttribute(AttributeName = "currencyID")]
    public string CurrencyID { get; set; }

    [XmlText]
    public double Text { get; set; }
}

[XmlRoot(ElementName = "TaxInclusiveAmount")]
public class TaxInclusiveAmount
{

    [XmlAttribute(AttributeName = "currencyID")]
    public string CurrencyID { get; set; }

    [XmlText]
    public DateTime Text { get; set; }
}

[XmlRoot(ElementName = "AllowanceTotalAmount")]
public class AllowanceTotalAmount
{

    [XmlAttribute(AttributeName = "currencyID")]
    public string CurrencyID { get; set; }

    [XmlText]
    public double Text { get; set; }
}

[XmlRoot(ElementName = "PayableAmount")]
public class PayableAmount
{

    [XmlAttribute(AttributeName = "currencyID")]
    public string CurrencyID { get; set; }

    [XmlText]
    public DateTime Text { get; set; }
}

[XmlRoot(ElementName = "LegalMonetaryTotal")]
public class LegalMonetaryTotal
{

    [XmlElement(ElementName = "LineExtensionAmount")]
    public LineExtensionAmount LineExtensionAmount { get; set; }

    [XmlElement(ElementName = "TaxExclusiveAmount")]
    public TaxExclusiveAmount TaxExclusiveAmount { get; set; }

    [XmlElement(ElementName = "TaxInclusiveAmount")]
    public TaxInclusiveAmount TaxInclusiveAmount { get; set; }

    [XmlElement(ElementName = "AllowanceTotalAmount")]
    public AllowanceTotalAmount AllowanceTotalAmount { get; set; }

    [XmlElement(ElementName = "PayableAmount")]
    public PayableAmount PayableAmount { get; set; }
}

[XmlRoot(ElementName = "InvoicedQuantity")]
public class InvoicedQuantity
{

    [XmlAttribute(AttributeName = "unitCode")]
    public string UnitCode { get; set; }

    [XmlText]
    public int Text { get; set; }
}

[XmlRoot(ElementName = "Item")]
public class Item
{

    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }
}

[XmlRoot(ElementName = "PriceAmount")]
public class PriceAmount
{

    [XmlAttribute(AttributeName = "currencyID")]
    public string CurrencyID { get; set; }

    [XmlText]
    public int Text { get; set; }
}

[XmlRoot(ElementName = "Price")]
public class Price
{

    [XmlElement(ElementName = "PriceAmount")]
    public PriceAmount PriceAmount { get; set; }
}

[XmlRoot(ElementName = "InvoiceLine")]
public class InvoiceLine
{

    [XmlElement(ElementName = "ID")]
    public int ID { get; set; }

    [XmlElement(ElementName = "InvoicedQuantity")]
    public InvoicedQuantity InvoicedQuantity { get; set; }

    [XmlElement(ElementName = "LineExtensionAmount")]
    public LineExtensionAmount LineExtensionAmount { get; set; }

    [XmlElement(ElementName = "TaxTotal")]
    public TaxTotal TaxTotal { get; set; }

    [XmlElement(ElementName = "Item")]
    public Item Item { get; set; }

    [XmlElement(ElementName = "Price")]
    public Price Price { get; set; }
}

[XmlRoot(ElementName = "Invoice")]
public class Invoice
{

    [XmlElement(ElementName = "UBLExtensions")]
    public UBLExtensions UBLExtensions { get; set; }

    [XmlElement(ElementName = "UBLVersionID")]
    public double UBLVersionID { get; set; }

    [XmlElement(ElementName = "CustomizationID")]
    public string CustomizationID { get; set; }

    [XmlElement(ElementName = "ProfileID")]
    public string ProfileID { get; set; }

    [XmlElement(ElementName = "ID")]
    public string ID { get; set; }

    [XmlElement(ElementName = "CopyIndicator")]
    public bool CopyIndicator { get; set; }

    [XmlElement(ElementName = "UUID")]
    public string UUID { get; set; }

    [XmlElement(ElementName = "IssueDate")]
    public DateTime IssueDate { get; set; }

    [XmlElement(ElementName = "InvoiceTypeCode")]
    public string InvoiceTypeCode { get; set; }

    [XmlElement(ElementName = "Note")]
    public string Note { get; set; }

    [XmlElement(ElementName = "DocumentCurrencyCode")]
    public DocumentCurrencyCode DocumentCurrencyCode { get; set; }

    [XmlElement(ElementName = "LineCountNumeric")]
    public int LineCountNumeric { get; set; }

    [XmlElement(ElementName = "AdditionalDocumentReference")]
    public AdditionalDocumentReference AdditionalDocumentReference { get; set; }

    [XmlElement(ElementName = "Signature")]
    public Signature Signature { get; set; }

    [XmlElement(ElementName = "AccountingSupplierParty")]
    public AccountingSupplierParty AccountingSupplierParty { get; set; }

    [XmlElement(ElementName = "AccountingCustomerParty")]
    public AccountingCustomerParty AccountingCustomerParty { get; set; }

    [XmlElement(ElementName = "TaxTotal")]
    public TaxTotal TaxTotal { get; set; }

    [XmlElement(ElementName = "LegalMonetaryTotal")]
    public LegalMonetaryTotal LegalMonetaryTotal { get; set; }

    [XmlElement(ElementName = "InvoiceLine")]
    public InvoiceLine InvoiceLine { get; set; }

    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }

    [XmlAttribute(AttributeName = "cac")]
    public string Cac { get; set; }

    [XmlAttribute(AttributeName = "xades")]
    public string Xades { get; set; }

    [XmlAttribute(AttributeName = "udt")]
    public string Udt { get; set; }

    [XmlAttribute(AttributeName = "cbc")]
    public string Cbc { get; set; }

    [XmlAttribute(AttributeName = "ccts")]
    public string Ccts { get; set; }

    [XmlAttribute(AttributeName = "ubltr")]
    public string Ubltr { get; set; }

    [XmlAttribute(AttributeName = "qdt")]
    public string Qdt { get; set; }

    [XmlAttribute(AttributeName = "ext")]
    public string Ext { get; set; }

    [XmlAttribute(AttributeName = "ds")]
    public string Ds { get; set; }

    [XmlAttribute(AttributeName = "xsi")]
    public string Xsi { get; set; }

    [XmlAttribute(AttributeName = "schemaLocation")]
    public string SchemaLocation { get; set; }

    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "ElementList")]
public class ElementList
{

    [XmlElement(ElementName = "Invoice")]
    public Invoice Invoice { get; set; }
}

[XmlRoot(ElementName = "Elements")]
public class Elements
{

    [XmlElement(ElementName = "ElementType")]
    public string ElementType { get; set; }

    [XmlElement(ElementName = "ElementCount")]
    public int ElementCount { get; set; }

    [XmlElement(ElementName = "ElementList")]
    public ElementList ElementList { get; set; }
}

[XmlRoot(ElementName = "Package")]
public class Package
{

    [XmlElement(ElementName = "Elements")]
    public Elements Elements { get; set; }
}

[XmlRoot(ElementName = "StandardBusinessDocument")]
public class StandardBusinessDocument
{

    [XmlElement(ElementName = "StandardBusinessDocumentHeader")]
    public StandardBusinessDocumentHeader StandardBusinessDocumentHeader { get; set; }

    [XmlElement(ElementName = "Package")]
    public Package Package { get; set; }

    [XmlAttribute(AttributeName = "schemaLocation")]
    public string SchemaLocation { get; set; }

    [XmlAttribute(AttributeName = "sh")]
    public string Sh { get; set; }

    [XmlAttribute(AttributeName = "ef")]
    public string Ef { get; set; }

    [XmlAttribute(AttributeName = "xsi")]
    public string Xsi { get; set; }

    [XmlText]
    public string Text { get; set; }
}

