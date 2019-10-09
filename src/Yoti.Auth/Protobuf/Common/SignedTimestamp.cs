// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: SignedTimestamp.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Yoti.Auth.ProtoBuf.Common {

  /// <summary>Holder for reflection information generated from SignedTimestamp.proto</summary>
  public static partial class SignedTimestampReflection {

    #region Descriptor
    /// <summary>File descriptor for SignedTimestamp.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SignedTimestampReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChVTaWduZWRUaW1lc3RhbXAucHJvdG8SDGNvbXB1YmFwaV92MSKbAQoPU2ln",
            "bmVkVGltZXN0YW1wEg8KB3ZlcnNpb24YASABKAUSEQoJdGltZXN0YW1wGAIg",
            "ASgEEhYKDm1lc3NhZ2VfZGlnZXN0GAMgASgMEhQKDGNoYWluX2RpZ2VzdBgE",
            "IAEoDBIaChJjaGFpbl9kaWdlc3Rfc2tpcDEYBSABKAwSGgoSY2hhaW5fZGln",
            "ZXN0X3NraXAyGAYgASgMQnIKJGNvbS55b3RpLmFwaS5jbGllbnQuc3BpLnJl",
            "bW90ZS5wcm90b0IUU2lnbmVkVGltZXN0YW1wUHJvdG9aDHlvdGlwcm90b2Nv",
            "baoCGVlvdGkuQXV0aC5Qcm90b0J1Zi5Db21tb27KAglDb21wdWJhcGliBnBy",
            "b3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Yoti.Auth.ProtoBuf.Common.SignedTimestamp), global::Yoti.Auth.ProtoBuf.Common.SignedTimestamp.Parser, new[]{ "Version", "Timestamp", "MessageDigest", "ChainDigest", "ChainDigestSkip1", "ChainDigestSkip2" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SignedTimestamp : pb::IMessage<SignedTimestamp> {
    private static readonly pb::MessageParser<SignedTimestamp> _parser = new pb::MessageParser<SignedTimestamp>(() => new SignedTimestamp());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SignedTimestamp> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Yoti.Auth.ProtoBuf.Common.SignedTimestampReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SignedTimestamp() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SignedTimestamp(SignedTimestamp other) : this() {
      version_ = other.version_;
      timestamp_ = other.timestamp_;
      messageDigest_ = other.messageDigest_;
      chainDigest_ = other.chainDigest_;
      chainDigestSkip1_ = other.chainDigestSkip1_;
      chainDigestSkip2_ = other.chainDigestSkip2_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SignedTimestamp Clone() {
      return new SignedTimestamp(this);
    }

    /// <summary>Field number for the "version" field.</summary>
    public const int VersionFieldNumber = 1;
    private int version_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Version {
      get { return version_; }
      set {
        version_ = value;
      }
    }

    /// <summary>Field number for the "timestamp" field.</summary>
    public const int TimestampFieldNumber = 2;
    private ulong timestamp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong Timestamp {
      get { return timestamp_; }
      set {
        timestamp_ = value;
      }
    }

    /// <summary>Field number for the "message_digest" field.</summary>
    public const int MessageDigestFieldNumber = 3;
    private pb::ByteString messageDigest_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString MessageDigest {
      get { return messageDigest_; }
      set {
        messageDigest_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "chain_digest" field.</summary>
    public const int ChainDigestFieldNumber = 4;
    private pb::ByteString chainDigest_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString ChainDigest {
      get { return chainDigest_; }
      set {
        chainDigest_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "chain_digest_skip1" field.</summary>
    public const int ChainDigestSkip1FieldNumber = 5;
    private pb::ByteString chainDigestSkip1_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString ChainDigestSkip1 {
      get { return chainDigestSkip1_; }
      set {
        chainDigestSkip1_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "chain_digest_skip2" field.</summary>
    public const int ChainDigestSkip2FieldNumber = 6;
    private pb::ByteString chainDigestSkip2_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString ChainDigestSkip2 {
      get { return chainDigestSkip2_; }
      set {
        chainDigestSkip2_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SignedTimestamp);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SignedTimestamp other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Version != other.Version) return false;
      if (Timestamp != other.Timestamp) return false;
      if (MessageDigest != other.MessageDigest) return false;
      if (ChainDigest != other.ChainDigest) return false;
      if (ChainDigestSkip1 != other.ChainDigestSkip1) return false;
      if (ChainDigestSkip2 != other.ChainDigestSkip2) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Version != 0) hash ^= Version.GetHashCode();
      if (Timestamp != 0UL) hash ^= Timestamp.GetHashCode();
      if (MessageDigest.Length != 0) hash ^= MessageDigest.GetHashCode();
      if (ChainDigest.Length != 0) hash ^= ChainDigest.GetHashCode();
      if (ChainDigestSkip1.Length != 0) hash ^= ChainDigestSkip1.GetHashCode();
      if (ChainDigestSkip2.Length != 0) hash ^= ChainDigestSkip2.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Version != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Version);
      }
      if (Timestamp != 0UL) {
        output.WriteRawTag(16);
        output.WriteUInt64(Timestamp);
      }
      if (MessageDigest.Length != 0) {
        output.WriteRawTag(26);
        output.WriteBytes(MessageDigest);
      }
      if (ChainDigest.Length != 0) {
        output.WriteRawTag(34);
        output.WriteBytes(ChainDigest);
      }
      if (ChainDigestSkip1.Length != 0) {
        output.WriteRawTag(42);
        output.WriteBytes(ChainDigestSkip1);
      }
      if (ChainDigestSkip2.Length != 0) {
        output.WriteRawTag(50);
        output.WriteBytes(ChainDigestSkip2);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Version != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Version);
      }
      if (Timestamp != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(Timestamp);
      }
      if (MessageDigest.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(MessageDigest);
      }
      if (ChainDigest.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(ChainDigest);
      }
      if (ChainDigestSkip1.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(ChainDigestSkip1);
      }
      if (ChainDigestSkip2.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(ChainDigestSkip2);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SignedTimestamp other) {
      if (other == null) {
        return;
      }
      if (other.Version != 0) {
        Version = other.Version;
      }
      if (other.Timestamp != 0UL) {
        Timestamp = other.Timestamp;
      }
      if (other.MessageDigest.Length != 0) {
        MessageDigest = other.MessageDigest;
      }
      if (other.ChainDigest.Length != 0) {
        ChainDigest = other.ChainDigest;
      }
      if (other.ChainDigestSkip1.Length != 0) {
        ChainDigestSkip1 = other.ChainDigestSkip1;
      }
      if (other.ChainDigestSkip2.Length != 0) {
        ChainDigestSkip2 = other.ChainDigestSkip2;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Version = input.ReadInt32();
            break;
          }
          case 16: {
            Timestamp = input.ReadUInt64();
            break;
          }
          case 26: {
            MessageDigest = input.ReadBytes();
            break;
          }
          case 34: {
            ChainDigest = input.ReadBytes();
            break;
          }
          case 42: {
            ChainDigestSkip1 = input.ReadBytes();
            break;
          }
          case 50: {
            ChainDigestSkip2 = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
