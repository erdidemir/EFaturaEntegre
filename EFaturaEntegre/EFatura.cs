using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;

public class EFatura
{
    public StandardBusinessDocument GetFatura()
    {
        // �rnek bir StandardBusinessDocument olu�tur
        StandardBusinessDocument sbd = new StandardBusinessDocument
        {
            StandardBusinessDocumentHeader = new StandardBusinessDocumentHeader
            {
                // Header bilgilerini doldur
                // �rnek veri ile dolduruldu, ger�ek verilerle de�i�tirilmeli
                HeaderVersion = 1.0,
                Sender = new Sender
                {
                    Identifier = "SenderIdentifier",
                    ContactInformation = new List<ContactInformation>
                    {
                        new ContactInformation
                        {
                            Contact = "SenderContact",
                            ContactTypeIdentifier = "SenderContactType"
                        }
                    }
                },
                Receiver = new Receiver
                {
                    Identifier = "ReceiverIdentifier",
                    ContactInformation = new List<ContactInformation>
                    {
                        new ContactInformation
                        {
                            Contact = "ReceiverContact",
                            ContactTypeIdentifier = "ReceiverContactType"
                        }
                    }
                },
                DocumentIdentification = new DocumentIdentification
                {
                    Standard = "ExampleStandard",
                    TypeVersion = 1.0,
                    InstanceIdentifier = Guid.NewGuid().ToString(),
                    Type = "ExampleType",
                    CreationDateAndTime = DateTime.UtcNow
                }
            },
            Package = new Package
            {
                Elements = new Elements
                {
                    ElementType = "ExampleElementType",
                    ElementCount = 1,
                    ElementList = new ElementList
                    {
                        Invoice = new Invoice
                        {
                            // Fatura bilgilerini doldur
                            // �rnek veri ile dolduruldu, ger�ek verilerle de�i�tirilmeli
                            UBLVersionID = 2.1,
                            CustomizationID = "CustomizationID",
                            ProfileID = "ProfileID",
                            ID = "InvoiceID",
                            CopyIndicator = false,
                            UUID = Guid.NewGuid().ToString(),
                            IssueDate = DateTime.UtcNow,
                            InvoiceTypeCode = "InvoiceType",
                            Note = "Example note",
                            DocumentCurrencyCode = new DocumentCurrencyCode
                            {
                                ListAgencyName = "CurrencyListAgency",
                                ListID = "CurrencyListID",
                                ListName = "CurrencyListName",
                                ListVersionID = 1,
                                Text = "USD"
                            },
                            LineCountNumeric = 1,
                            // Di�er fatura detaylar� buraya eklenmeli
                            // Bu sadece �rnek bir veridir
                            InvoiceLine = new InvoiceLine
                            {
                                ID = 1,
                                InvoicedQuantity = new InvoicedQuantity
                                {
                                    UnitCode = "UnitCode",
                                    Text = 1
                                },
                                LineExtensionAmount = new LineExtensionAmount
                                {
                                    CurrencyID = "USD",
                                    Text = 100
                                },
                                // Di�er detaylar buraya eklenecek
                                // �rnek veri ile dolduruldu, ger�ek verilerle de�i�tirilmeli
                                Item = new Item
                                {
                                    Name = "ItemName"
                                },
                                Price = new Price
                                {
                                    PriceAmount = new PriceAmount
                                    {
                                        CurrencyID = "USD",
                                        Text = 100
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        return sbd;
    }


    public void GetFatura2(StandardBusinessDocument standardBusinessDocument)
    {
        // XML belgesi olu�turma
        XmlDocument xmlDoc = new XmlDocument();

        // K�k ��e olu�turma
        XmlElement root = xmlDoc.CreateElement("sh:StandardBusinessDocument");
        xmlDoc.AppendChild(root);

        // xsi, sh, ef isim alanlar�n� ekleyin
        XmlAttribute xsiAttr = xmlDoc.CreateAttribute("xmlns:xsi");
        xsiAttr.Value = "http://www.w3.org/2001/XMLSchema-instance";
        root.Attributes.Append(xsiAttr);

        XmlAttribute schemaLocAttr = xmlDoc.CreateAttribute("xsi:schemaLocation");
        schemaLocAttr.Value = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader PackageProxy_1_2.xsd";
        root.Attributes.Append(schemaLocAttr);

        XmlAttribute shAttr = xmlDoc.CreateAttribute("xmlns:sh");
        shAttr.Value = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader";
        root.Attributes.Append(shAttr);

        XmlAttribute efAttr = xmlDoc.CreateAttribute("xmlns:ef");
        efAttr.Value = "http://www.efatura.gov.tr/package-namespace";
        root.Attributes.Append(efAttr);

        #region <sh:StandardBusinessDocumentHeader>

        // StandardBusinessDocumentHeader ��esini olu�turma
        XmlElement header = xmlDoc.CreateElement("sh:StandardBusinessDocumentHeader");
        root.AppendChild(header);

        // Sender ��esini olu�turma
        XmlElement sender = xmlDoc.CreateElement("sh:Sender");
        header.AppendChild(sender);

        // Sender'�n Identifier ��esini olu�turma
        XmlElement senderIdentifier = xmlDoc.CreateElement("sh:Identifier");
        senderIdentifier.InnerText = "urn:mail:defaultgb@gib.gov.tr";
        sender.AppendChild(senderIdentifier);

        // Sender'�n ContactInformation ��elerini olu�turma
        XmlElement senderContactInfo1 = xmlDoc.CreateElement("sh:ContactInformation");
        sender.AppendChild(senderContactInfo1);

        XmlElement senderContact1 = xmlDoc.CreateElement("sh:Contact");
        senderContact1.InnerText = "e-Fatura Deneme A.�.";
        senderContactInfo1.AppendChild(senderContact1);

        XmlElement senderContactType1 = xmlDoc.CreateElement("sh:ContactTypeIdentifier");
        senderContactType1.InnerText = "UNVAN";
        senderContactInfo1.AppendChild(senderContactType1);

        XmlElement senderContactInfo2 = xmlDoc.CreateElement("sh:ContactInformation");
        sender.AppendChild(senderContactInfo2);

        XmlElement senderContact2 = xmlDoc.CreateElement("sh:Contact");
        senderContact2.InnerText = "9999999999";
        senderContactInfo2.AppendChild(senderContact2);

        XmlElement senderContactType2 = xmlDoc.CreateElement("sh:ContactTypeIdentifier");
        senderContactType2.InnerText = "VKN_TCKN";
        senderContactInfo2.AppendChild(senderContactType2);

        // Receiver ��esini olu�turma (Sender ile benzer �ekilde)
        XmlElement receiver = xmlDoc.CreateElement("sh:Receiver");
        header.AppendChild(receiver);

        // DocumentIdentification ��esini olu�turma
        XmlElement docIdentification = xmlDoc.CreateElement("sh:DocumentIdentification");
        header.AppendChild(docIdentification);

        #endregion


        // DocumentIdentification'�n alt ��elerini olu�turma
        XmlElement standard = xmlDoc.CreateElement("sh:Standard");
        docIdentification.AppendChild(standard);

        XmlElement typeVersion = xmlDoc.CreateElement("sh:TypeVersion");
        typeVersion.InnerText = "1.0";
        docIdentification.AppendChild(typeVersion);

        XmlElement instanceIdentifier = xmlDoc.CreateElement("sh:InstanceIdentifier");
        instanceIdentifier.InnerText = "e002da78-223f-438c-addb-16badeb047b5";
        docIdentification.AppendChild(instanceIdentifier);

        XmlElement type = xmlDoc.CreateElement("sh:Type");
        type.InnerText = "SENDERENVELOPE";
        docIdentification.AppendChild(type);

        XmlElement creationDateAndTime = xmlDoc.CreateElement("sh:CreationDateAndTime");
        creationDateAndTime.InnerText = "2013-06-19T14:47:55";
        docIdentification.AppendChild(creationDateAndTime);

        // Package ��esini olu�turma
        XmlElement package = xmlDoc.CreateElement("ef:Package");
        root.AppendChild(package);

        // Package'�n alt ��elerini olu�turma
        XmlElement elements = xmlDoc.CreateElement("Elements");
        package.AppendChild(elements);

        XmlElement elementType = xmlDoc.CreateElement("ElementType");
        elementType.InnerText = "INVOICE";
        elements.AppendChild(elementType);

        XmlElement elementCount = xmlDoc.CreateElement("ElementCount");
        elementCount.InnerText = "1";
        elements.AppendChild(elementCount);

        XmlElement elementList = xmlDoc.CreateElement("ElementList");
        elements.AppendChild(elementList);

        // Invoice ��esini olu�turma
        XmlElement invoice = xmlDoc.CreateElement("Invoice", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
        invoice.SetAttribute("xmlns:cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
        // ... Di�er namespace'leri ve attribute'leri buraya ekleyebilirsiniz ...

        elementList.AppendChild(invoice);

        // Invoice'�n alt ��elerini olu�turma

        // ext:UBLExtensions ��esi
        XmlElement ublExtensions = xmlDoc.CreateElement("ext:UBLExtensions");
        invoice.AppendChild(ublExtensions);

        // ext:UBLExtension ��esi
        XmlElement ublExtension = xmlDoc.CreateElement("ext:UBLExtension");
        ublExtensions.AppendChild(ublExtension);

        // ext:ExtensionContent ��esi
        XmlElement extensionContent = xmlDoc.CreateElement("ext:ExtensionContent");
        ublExtension.AppendChild(extensionContent);

        // ds:Signature ��esi
        XmlElement signature = xmlDoc.CreateElement("ds:Signature", "http://www.w3.org/2000/09/xmldsig#");
        extensionContent.AppendChild(signature);

        // ds:SignedInfo ��esi
        XmlElement signedInfo = xmlDoc.CreateElement("ds:SignedInfo");
        signature.AppendChild(signedInfo);

        // ds:CanonicalizationMethod ��esi
        XmlElement canonicalizationMethod = xmlDoc.CreateElement("ds:CanonicalizationMethod");
        canonicalizationMethod.SetAttribute("Algorithm", "http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments");
        signedInfo.AppendChild(canonicalizationMethod);

        // ds:SignatureMethod ��esi
        XmlElement signatureMethod = xmlDoc.CreateElement("ds:SignatureMethod");
        signatureMethod.SetAttribute("Algorithm", "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");
        signedInfo.AppendChild(signatureMethod);

        // ds:Reference ��esi
        XmlElement reference = xmlDoc.CreateElement("ds:Reference");
        reference.SetAttribute("URI", "");
        signedInfo.AppendChild(reference);

        // ... ds:Reference alt ��eleri buraya eklenmeli (ds:DigestMethod, ds:Transforms, ds:DigestValue) ...

        // ds:SignatureValue ��esi
        XmlElement signatureValue = xmlDoc.CreateElement("ds:SignatureValue");
        signatureValue.SetAttribute("Id", "id1");
        signatureValue.InnerText = "..."; // Buraya imza de�erini eklemelisiniz
        signature.AppendChild(signatureValue);

        // ds:KeyInfo ��esi
        XmlElement keyInfo = xmlDoc.CreateElement("ds:KeyInfo");
        signature.AppendChild(keyInfo);

        // ... ds:KeyInfo alt ��eleri buraya eklenmeli (ds:KeyValue, ds:X509Data) ...

        // ds:Object ��esi
        XmlElement obj = xmlDoc.CreateElement("ds:Object");
        signature.AppendChild(obj);

        // xades:QualifyingProperties ��esi
        XmlElement qualifyingProps = xmlDoc.CreateElement("xades:QualifyingProperties");
        qualifyingProps.SetAttribute("Target", "#Signature_TST2013000000766");
        obj.AppendChild(qualifyingProps);

        // xades:SignedProperties ��esi
        XmlElement signedProps = xmlDoc.CreateElement("xades:SignedProperties");
        signedProps.SetAttribute("Id", "SignedProperties");
        qualifyingProps.AppendChild(signedProps);

        // xades:SignedSignatureProperties ��esi
        XmlElement signedSigProps = xmlDoc.CreateElement("xades:SignedSignatureProperties");
        signedProps.AppendChild(signedSigProps);

        // xades:SigningTime ��esi
        XmlElement signingTime = xmlDoc.CreateElement("xades:SigningTime");
        signingTime.InnerText = "2013-06-19T14:47:55.311+03:00";
        signedSigProps.AppendChild(signingTime);

        // xades:SigningCertificate ��esi
        // ... Di�er alt ��eleri buraya eklemelisiniz ...

        // xades:SignerRole ��esi
        XmlElement signerRole = xmlDoc.CreateElement("xades:SignerRole");
        signedSigProps.AppendChild(signerRole);

        // xades:ClaimedRoles ��esi
        XmlElement claimedRoles = xmlDoc.CreateElement("xades:ClaimedRoles");
        signerRole.AppendChild(claimedRoles);

        // xades:ClaimedRole ��esi
        XmlElement claimedRole = xmlDoc.CreateElement("xades:ClaimedRole");
        claimedRole.InnerText = "Tedarik�i";
        claimedRoles.AppendChild(claimedRole);

        // Di�er alt ��elerin eklenmesi...

        // ds:Reference alt ��eleri
        XmlElement transforms = xmlDoc.CreateElement("ds:Transforms");
        XmlElement transform = xmlDoc.CreateElement("ds:Transform");
        transform.SetAttribute("Algorithm", "http://www.w3.org/2000/09/xmldsig#enveloped-signature");
        transforms.AppendChild(transform);
        reference.AppendChild(transforms);

        XmlElement digestMethod = xmlDoc.CreateElement("ds:DigestMethod");
        digestMethod.SetAttribute("Algorithm", "http://www.w3.org/2001/04/xmlenc#sha256");
        reference.AppendChild(digestMethod);

        XmlElement digestValue = xmlDoc.CreateElement("ds:DigestValue");
        digestValue.InnerText = "mlTwy1zNm4dBEo1Q/97X9gBxOn0tIfsMKFzb++8RmGA="; // Buraya digest de�erini ekleyin
        reference.AppendChild(digestValue);

        // ds:KeyInfo alt ��eleri
        XmlElement keyValue = xmlDoc.CreateElement("ds:KeyValue");
        XmlElement rsaKeyValue = xmlDoc.CreateElement("ds:RSAKeyValue");
        keyValue.AppendChild(rsaKeyValue);
        keyInfo.AppendChild(keyValue);

        // Burada RSA Key Value alt ��eleri (ds:Modulus ve ds:Exponent) eklenmelidir
        // Modulus ve Exponent de�erlerini kendi kullan�m durumunuza g�re eklemelisiniz

        XmlElement modulus = xmlDoc.CreateElement("ds:Modulus");
        modulus.InnerText = "g4fWV5+GRbNQTnVpG5naG/4xC167blIngQJdOJVss7LSBjFkOOitvJtpV0Qvsld1HzW9A+P8aR17KdgZzqsc5+akR0+volN2ZH9M+q0Xza7zSQjgBzovv2R6VQWLnEyFb4i3PzEqQMDbF8n30oNWj0BjBvNn+eTkxmk8ifhLDAwrrDasje5CudTNo9pIv73VcJqA3F+pKwW7MGIZeDJpLnbbqz+ELOIR3ev51Ewb889QQyqlMiu2LKaDVmpsFzAlFo25ayLTJ896/cL0Lff+/W+CKeOo3f/SrAcZWp0RWmiKZDET9LqCodeH+2x3M8+KK2IwjABk378e8/TipjfENQ==";
        rsaKeyValue.AppendChild(modulus);

        XmlElement exponent = xmlDoc.CreateElement("ds:Exponent");
        exponent.InnerText = "AQAB";
        rsaKeyValue.AppendChild(exponent);

        // ds:X509Data alt ��eleri
        XmlElement x509Data = xmlDoc.CreateElement("ds:X509Data");
        XmlElement x509SubjectName = xmlDoc.CreateElement("ds:X509SubjectName");
        x509SubjectName.InnerText = "CN=e-Fatura Deneme A.�.,2.5.4.5=#130a39393939393939393939,OU=e-Fatura Deneme A.�.";
        x509Data.AppendChild(x509SubjectName);

        XmlElement x509Certificate = xmlDoc.CreateElement("ds:X509Certificate");
        x509Certificate.InnerText = "MIIFrDCCBJSgAwIBAgIGAJpaGcRq..."; // Buraya sertifika de�erini ekleyin
        x509Data.AppendChild(x509Certificate);

        keyInfo.AppendChild(x509Data);

        // ds:Object alt ��eleri
        XmlElement certObj = xmlDoc.CreateElement("xades:Certificate");
        // ... Di�er alt ��eleri buraya eklemelisiniz ...

        obj.AppendChild(certObj);

        // Di�er alt ��elerinizi ekleyin...

        // Son olarak XML'i konsola yazd�rma
        Console.WriteLine(xmlDoc.OuterXml);


        // XML'i konsola yazd�rma
        Console.WriteLine(xmlDoc.OuterXml);



        // Di�er ��eleri ekleyin...

        // �rnek XML'i konsola yazd�rma
        Console.WriteLine(xmlDoc.OuterXml);
    }
}
