using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;

namespace Newtonsoft.Json.Serialization
{
	internal class TraceJsonReader : JsonReader, IJsonLineInfo
	{
		private readonly JsonReader _innerReader;

		private readonly JsonTextWriter _textWriter;

		private readonly StringWriter _sw;

		public override int Depth
		{
			get
			{
				return this._innerReader.Depth;
			}
		}

		int Newtonsoft.Json.IJsonLineInfo.LineNumber
		{
			get
			{
				IJsonLineInfo jsonLineInfo = this._innerReader as IJsonLineInfo;
				IJsonLineInfo jsonLineInfo1 = jsonLineInfo;
				if (jsonLineInfo == null)
				{
					return 0;
				}
				return jsonLineInfo1.LineNumber;
			}
		}

		int Newtonsoft.Json.IJsonLineInfo.LinePosition
		{
			get
			{
				IJsonLineInfo jsonLineInfo = this._innerReader as IJsonLineInfo;
				IJsonLineInfo jsonLineInfo1 = jsonLineInfo;
				if (jsonLineInfo == null)
				{
					return 0;
				}
				return jsonLineInfo1.LinePosition;
			}
		}

		public override string Path
		{
			get
			{
				return this._innerReader.Path;
			}
		}

		public override char QuoteChar
		{
			get
			{
				return this._innerReader.QuoteChar;
			}
			protected internal set
			{
				this._innerReader.QuoteChar = value;
			}
		}

		public override JsonToken TokenType
		{
			get
			{
				return this._innerReader.TokenType;
			}
		}

		public override object Value
		{
			get
			{
				return this._innerReader.Value;
			}
		}

		public override Type ValueType
		{
			get
			{
				return this._innerReader.ValueType;
			}
		}

		public TraceJsonReader(JsonReader innerReader)
		{
			Class6.yDnXvgqzyB5jw();
			base();
			this._innerReader = innerReader;
			this._sw = new StringWriter(CultureInfo.InvariantCulture);
			this._sw.Write(string.Concat("Deserialized JSON: ", Environment.NewLine));
			this._textWriter = new JsonTextWriter(this._sw)
			{
				Formatting = Formatting.Indented
			};
		}

		public override void Close()
		{
			this._innerReader.Close();
		}

		public string GetDeserializedJsonMessage()
		{
			return this._sw.ToString();
		}

		bool Newtonsoft.Json.IJsonLineInfo.HasLineInfo()
		{
			IJsonLineInfo jsonLineInfo = this._innerReader as IJsonLineInfo;
			IJsonLineInfo jsonLineInfo1 = jsonLineInfo;
			if (jsonLineInfo == null)
			{
				return false;
			}
			return jsonLineInfo1.HasLineInfo();
		}

		public override bool Read()
		{
			bool flag = this._innerReader.Read();
			this.WriteCurrentToken();
			return flag;
		}

		public override bool? ReadAsBoolean()
		{
			bool? nullable = this._innerReader.ReadAsBoolean();
			this.WriteCurrentToken();
			return nullable;
		}

		public override byte[] ReadAsBytes()
		{
			byte[] numArray = this._innerReader.ReadAsBytes();
			this.WriteCurrentToken();
			return numArray;
		}

		public override DateTime? ReadAsDateTime()
		{
			DateTime? nullable = this._innerReader.ReadAsDateTime();
			this.WriteCurrentToken();
			return nullable;
		}

		public override DateTimeOffset? ReadAsDateTimeOffset()
		{
			DateTimeOffset? nullable = this._innerReader.ReadAsDateTimeOffset();
			this.WriteCurrentToken();
			return nullable;
		}

		public override decimal? ReadAsDecimal()
		{
			decimal? nullable = this._innerReader.ReadAsDecimal();
			this.WriteCurrentToken();
			return nullable;
		}

		public override double? ReadAsDouble()
		{
			double? nullable = this._innerReader.ReadAsDouble();
			this.WriteCurrentToken();
			return nullable;
		}

		public override string ReadAsString()
		{
			string str = this._innerReader.ReadAsString();
			this.WriteCurrentToken();
			return str;
		}

		public override int? vmethod_0()
		{
			int? nullable = this._innerReader.vmethod_0();
			this.WriteCurrentToken();
			return nullable;
		}

		public void WriteCurrentToken()
		{
			this._textWriter.WriteToken(this._innerReader, false, false, true);
		}
	}
}