module Fix44.MsgWriteFuncs

open OneOrTwo
open Fix44.Fields
open Fix44.FieldReadWriteFuncs
open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs
open Fix44.Messages


// tag: 0
let WriteHeartbeat (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:Heartbeat) = 
    let nextFreeIdx = Option.fold (WriteTestReqID dest) nextFreeIdx xx.TestReqID
    nextFreeIdx


// tag: A
let WriteLogon (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:Logon) = 
    let nextFreeIdx = WriteEncryptMethod dest nextFreeIdx xx.EncryptMethod
    let nextFreeIdx = WriteHeartBtInt dest nextFreeIdx xx.HeartBtInt
    let nextFreeIdx = Option.fold (WriteRawDataLength dest) nextFreeIdx xx.RawDataLength
    let nextFreeIdx = Option.fold (WriteRawData dest) nextFreeIdx xx.RawData
    let nextFreeIdx = Option.fold (WriteResetSeqNumFlag dest) nextFreeIdx xx.ResetSeqNumFlag
    let nextFreeIdx = Option.fold (WriteNextExpectedMsgSeqNum dest) nextFreeIdx xx.NextExpectedMsgSeqNum
    let nextFreeIdx = Option.fold (WriteMaxMessageSize dest) nextFreeIdx xx.MaxMessageSize
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoMsgTypesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoMsgTypes dest innerNextFreeIdx (Fix44.Fields.NoMsgTypes numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoMsgTypesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoMsgTypesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteTestMessageIndicator dest) nextFreeIdx xx.TestMessageIndicator
    let nextFreeIdx = Option.fold (WriteUsername dest) nextFreeIdx xx.Username
    let nextFreeIdx = Option.fold (WritePassword dest) nextFreeIdx xx.Password
    nextFreeIdx


// tag: 1
let WriteTestRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:TestRequest) = 
    let nextFreeIdx = WriteTestReqID dest nextFreeIdx xx.TestReqID
    nextFreeIdx


// tag: 2
let WriteResendRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:ResendRequest) = 
    let nextFreeIdx = WriteBeginSeqNo dest nextFreeIdx xx.BeginSeqNo
    let nextFreeIdx = WriteEndSeqNo dest nextFreeIdx xx.EndSeqNo
    nextFreeIdx


// tag: 3
let WriteReject (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:Reject) = 
    let nextFreeIdx = WriteRefSeqNum dest nextFreeIdx xx.RefSeqNum
    let nextFreeIdx = Option.fold (WriteRefTagID dest) nextFreeIdx xx.RefTagID
    let nextFreeIdx = Option.fold (WriteRefMsgType dest) nextFreeIdx xx.RefMsgType
    let nextFreeIdx = Option.fold (WriteSessionRejectReason dest) nextFreeIdx xx.SessionRejectReason
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: 4
let WriteSequenceReset (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:SequenceReset) = 
    let nextFreeIdx = Option.fold (WriteGapFillFlag dest) nextFreeIdx xx.GapFillFlag
    let nextFreeIdx = WriteNewSeqNo dest nextFreeIdx xx.NewSeqNo
    nextFreeIdx


// tag: 5
let WriteLogout (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:Logout) = 
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: j
let WriteBusinessMessageReject (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:BusinessMessageReject) = 
    let nextFreeIdx = Option.fold (WriteRefSeqNum dest) nextFreeIdx xx.RefSeqNum
    let nextFreeIdx = WriteRefMsgType dest nextFreeIdx xx.RefMsgType
    let nextFreeIdx = Option.fold (WriteBusinessRejectRefID dest) nextFreeIdx xx.BusinessRejectRefID
    let nextFreeIdx = WriteBusinessRejectReason dest nextFreeIdx xx.BusinessRejectReason
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: BE
let WriteUserRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:UserRequest) = 
    let nextFreeIdx = WriteUserRequestID dest nextFreeIdx xx.UserRequestID
    let nextFreeIdx = WriteUserRequestType dest nextFreeIdx xx.UserRequestType
    let nextFreeIdx = WriteUsername dest nextFreeIdx xx.Username
    let nextFreeIdx = Option.fold (WritePassword dest) nextFreeIdx xx.Password
    let nextFreeIdx = Option.fold (WriteNewPassword dest) nextFreeIdx xx.NewPassword
    let nextFreeIdx = Option.fold (WriteRawDataLength dest) nextFreeIdx xx.RawDataLength
    let nextFreeIdx = Option.fold (WriteRawData dest) nextFreeIdx xx.RawData
    nextFreeIdx


// tag: BF
let WriteUserResponse (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:UserResponse) = 
    let nextFreeIdx = WriteUserRequestID dest nextFreeIdx xx.UserRequestID
    let nextFreeIdx = WriteUsername dest nextFreeIdx xx.Username
    let nextFreeIdx = Option.fold (WriteUserStatus dest) nextFreeIdx xx.UserStatus
    let nextFreeIdx = Option.fold (WriteUserStatusText dest) nextFreeIdx xx.UserStatusText
    nextFreeIdx


// tag: 7
let WriteAdvertisement (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:Advertisement) = 
    let nextFreeIdx = WriteAdvId dest nextFreeIdx xx.AdvId
    let nextFreeIdx = WriteAdvTransType dest nextFreeIdx xx.AdvTransType
    let nextFreeIdx = Option.fold (WriteAdvRefID dest) nextFreeIdx xx.AdvRefID
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:Advertisement_NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteAdvertisement_NoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.Advertisement_NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = WriteAdvSide dest nextFreeIdx xx.AdvSide
    let nextFreeIdx = WriteQuantity dest nextFreeIdx xx.Quantity
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteURLLink dest) nextFreeIdx xx.URLLink
    let nextFreeIdx = Option.fold (WriteLastMkt dest) nextFreeIdx xx.LastMkt
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    nextFreeIdx


// tag: 6
let WriteIndicationOfInterest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:IndicationOfInterest) = 
    let nextFreeIdx = WriteIOIid dest nextFreeIdx xx.IOIid
    let nextFreeIdx = WriteIOITransType dest nextFreeIdx xx.IOITransType
    let nextFreeIdx = Option.fold (WriteIOIRefID dest) nextFreeIdx xx.IOIRefID
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = Option.fold (WriteOrderQtyData dest) nextFreeIdx xx.OrderQtyData    // component option
    let nextFreeIdx = WriteIOIQty dest nextFreeIdx xx.IOIQty
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:IndicationOfInterest_NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteIndicationOfInterest_NoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.IndicationOfInterest_NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WriteValidUntilTime dest) nextFreeIdx xx.ValidUntilTime
    let nextFreeIdx = Option.fold (WriteIOIQltyInd dest) nextFreeIdx xx.IOIQltyInd
    let nextFreeIdx = Option.fold (WriteIOINaturalFlag dest) nextFreeIdx xx.IOINaturalFlag
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoIOIQualifiersGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoIOIQualifiers dest innerNextFreeIdx (Fix44.Fields.NoIOIQualifiers numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoIOIQualifiersGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoIOIQualifiersGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteURLLink dest) nextFreeIdx xx.URLLink
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoRoutingIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoRoutingIDs dest innerNextFreeIdx (Fix44.Fields.NoRoutingIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoRoutingIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoRoutingIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    nextFreeIdx


// tag: B
let WriteNews (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:News) = 
    let nextFreeIdx = Option.fold (WriteOrigTime dest) nextFreeIdx xx.OrigTime
    let nextFreeIdx = Option.fold (WriteUrgency dest) nextFreeIdx xx.Urgency
    let nextFreeIdx = WriteHeadline dest nextFreeIdx xx.Headline
    let nextFreeIdx = Option.fold (WriteEncodedHeadline dest) nextFreeIdx xx.EncodedHeadline
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoRoutingIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoRoutingIDs dest innerNextFreeIdx (Fix44.Fields.NoRoutingIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoRoutingIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoRoutingIDsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoRelatedSymGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoRelatedSym dest innerNextFreeIdx (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoRelatedSymGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoRelatedSymGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let numGrps = xx.LinesOfTextGrp.Length
    let nextFreeIdx = WriteLinesOfText dest nextFreeIdx (Fix44.Fields.LinesOfText numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.LinesOfTextGrp |> List.fold (fun accFreeIdx gg -> WriteLinesOfTextGrp dest accFreeIdx gg) nextFreeIdx
    let nextFreeIdx = Option.fold (WriteURLLink dest) nextFreeIdx xx.URLLink
    let nextFreeIdx = Option.fold (WriteRawDataLength dest) nextFreeIdx xx.RawDataLength
    let nextFreeIdx = Option.fold (WriteRawData dest) nextFreeIdx xx.RawData
    nextFreeIdx


// tag: C
let WriteEmail (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:Email) = 
    let nextFreeIdx = WriteEmailThreadID dest nextFreeIdx xx.EmailThreadID
    let nextFreeIdx = WriteEmailType dest nextFreeIdx xx.EmailType
    let nextFreeIdx = Option.fold (WriteOrigTime dest) nextFreeIdx xx.OrigTime
    let nextFreeIdx = WriteSubject dest nextFreeIdx xx.Subject
    let nextFreeIdx = Option.fold (WriteEncodedSubject dest) nextFreeIdx xx.EncodedSubject
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoRoutingIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoRoutingIDs dest innerNextFreeIdx (Fix44.Fields.NoRoutingIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoRoutingIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoRoutingIDsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoRelatedSymGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoRelatedSym dest innerNextFreeIdx (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoRelatedSymGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoRelatedSymGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let numGrps = xx.LinesOfTextGrp.Length
    let nextFreeIdx = WriteLinesOfText dest nextFreeIdx (Fix44.Fields.LinesOfText numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.LinesOfTextGrp |> List.fold (fun accFreeIdx gg -> WriteLinesOfTextGrp dest accFreeIdx gg) nextFreeIdx
    let nextFreeIdx = Option.fold (WriteRawDataLength dest) nextFreeIdx xx.RawDataLength
    let nextFreeIdx = Option.fold (WriteRawData dest) nextFreeIdx xx.RawData
    nextFreeIdx


// tag: R
let WriteQuoteRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:QuoteRequest) = 
    let nextFreeIdx = WriteQuoteReqID dest nextFreeIdx xx.QuoteReqID
    let nextFreeIdx = Option.fold (WriteRFQReqID dest) nextFreeIdx xx.RFQReqID
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let numGrps = xx.QuoteRequest_NoRelatedSymGrp.Length
    let nextFreeIdx = WriteNoRelatedSym dest nextFreeIdx (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.QuoteRequest_NoRelatedSymGrp |> List.fold (fun accFreeIdx gg -> WriteQuoteRequest_NoRelatedSymGrp dest accFreeIdx gg) nextFreeIdx
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AJ
let WriteQuoteResponse (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:QuoteResponse) = 
    let nextFreeIdx = WriteQuoteRespID dest nextFreeIdx xx.QuoteRespID
    let nextFreeIdx = Option.fold (WriteQuoteID dest) nextFreeIdx xx.QuoteID
    let nextFreeIdx = WriteQuoteRespType dest nextFreeIdx xx.QuoteRespType
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WriteIOIid dest) nextFreeIdx xx.IOIid
    let nextFreeIdx = Option.fold (WriteQuoteType dest) nextFreeIdx xx.QuoteType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoQuoteQualifiersGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoQuoteQualifiers dest innerNextFreeIdx (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoQuoteQualifiersGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoQuoteQualifiersGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteOrderQtyData dest) nextFreeIdx xx.OrderQtyData    // component option
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteSettlDate2 dest) nextFreeIdx xx.SettlDate2
    let nextFreeIdx = Option.fold (WriteOrderQty2 dest) nextFreeIdx xx.OrderQty2
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:QuoteResponse_NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteQuoteResponse_NoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.QuoteResponse_NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteBidPx dest) nextFreeIdx xx.BidPx
    let nextFreeIdx = Option.fold (WriteOfferPx dest) nextFreeIdx xx.OfferPx
    let nextFreeIdx = Option.fold (WriteMktBidPx dest) nextFreeIdx xx.MktBidPx
    let nextFreeIdx = Option.fold (WriteMktOfferPx dest) nextFreeIdx xx.MktOfferPx
    let nextFreeIdx = Option.fold (WriteMinBidSize dest) nextFreeIdx xx.MinBidSize
    let nextFreeIdx = Option.fold (WriteBidSize dest) nextFreeIdx xx.BidSize
    let nextFreeIdx = Option.fold (WriteMinOfferSize dest) nextFreeIdx xx.MinOfferSize
    let nextFreeIdx = Option.fold (WriteOfferSize dest) nextFreeIdx xx.OfferSize
    let nextFreeIdx = Option.fold (WriteValidUntilTime dest) nextFreeIdx xx.ValidUntilTime
    let nextFreeIdx = Option.fold (WriteBidSpotRate dest) nextFreeIdx xx.BidSpotRate
    let nextFreeIdx = Option.fold (WriteOfferSpotRate dest) nextFreeIdx xx.OfferSpotRate
    let nextFreeIdx = Option.fold (WriteBidForwardPoints dest) nextFreeIdx xx.BidForwardPoints
    let nextFreeIdx = Option.fold (WriteOfferForwardPoints dest) nextFreeIdx xx.OfferForwardPoints
    let nextFreeIdx = Option.fold (WriteMidPx dest) nextFreeIdx xx.MidPx
    let nextFreeIdx = Option.fold (WriteBidYield dest) nextFreeIdx xx.BidYield
    let nextFreeIdx = Option.fold (WriteMidYield dest) nextFreeIdx xx.MidYield
    let nextFreeIdx = Option.fold (WriteOfferYield dest) nextFreeIdx xx.OfferYield
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteOrdType dest) nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WriteBidForwardPoints2 dest) nextFreeIdx xx.BidForwardPoints2
    let nextFreeIdx = Option.fold (WriteOfferForwardPoints2 dest) nextFreeIdx xx.OfferForwardPoints2
    let nextFreeIdx = Option.fold (WriteSettlCurrBidFxRate dest) nextFreeIdx xx.SettlCurrBidFxRate
    let nextFreeIdx = Option.fold (WriteSettlCurrOfferFxRate dest) nextFreeIdx xx.SettlCurrOfferFxRate
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRateCalc dest) nextFreeIdx xx.SettlCurrFxRateCalc
    let nextFreeIdx = Option.fold (WriteCommission dest) nextFreeIdx xx.Commission
    let nextFreeIdx = Option.fold (WriteCommType dest) nextFreeIdx xx.CommType
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteExDestination dest) nextFreeIdx xx.ExDestination
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    nextFreeIdx


// tag: AG
let WriteQuoteRequestReject (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:QuoteRequestReject) = 
    let nextFreeIdx = WriteQuoteReqID dest nextFreeIdx xx.QuoteReqID
    let nextFreeIdx = Option.fold (WriteRFQReqID dest) nextFreeIdx xx.RFQReqID
    let nextFreeIdx = WriteQuoteRequestRejectReason dest nextFreeIdx xx.QuoteRequestRejectReason
    let numGrps = xx.QuoteRequestReject_NoRelatedSymGrp.Length
    let nextFreeIdx = WriteNoRelatedSym dest nextFreeIdx (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.QuoteRequestReject_NoRelatedSymGrp |> List.fold (fun accFreeIdx gg -> WriteQuoteRequestReject_NoRelatedSymGrp dest accFreeIdx gg) nextFreeIdx
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoQuoteQualifiersGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoQuoteQualifiers dest innerNextFreeIdx (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoQuoteQualifiersGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoQuoteQualifiersGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteQuotePriceType dest) nextFreeIdx xx.QuotePriceType
    let nextFreeIdx = Option.fold (WriteOrdType dest) nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WritePrice2 dest) nextFreeIdx xx.Price2
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AH
let WriteRFQRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:RFQRequest) = 
    let nextFreeIdx = WriteRFQReqID dest nextFreeIdx xx.RFQReqID
    let numGrps = xx.RFQRequest_NoRelatedSymGrp.Length
    let nextFreeIdx = WriteNoRelatedSym dest nextFreeIdx (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.RFQRequest_NoRelatedSymGrp |> List.fold (fun accFreeIdx gg -> WriteRFQRequest_NoRelatedSymGrp dest accFreeIdx gg) nextFreeIdx
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    nextFreeIdx


// tag: S
let WriteQuote (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:Quote) = 
    let nextFreeIdx = Option.fold (WriteQuoteReqID dest) nextFreeIdx xx.QuoteReqID
    let nextFreeIdx = WriteQuoteID dest nextFreeIdx xx.QuoteID
    let nextFreeIdx = Option.fold (WriteQuoteRespID dest) nextFreeIdx xx.QuoteRespID
    let nextFreeIdx = Option.fold (WriteQuoteType dest) nextFreeIdx xx.QuoteType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoQuoteQualifiersGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoQuoteQualifiers dest innerNextFreeIdx (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoQuoteQualifiersGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoQuoteQualifiersGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteQuoteResponseLevel dest) nextFreeIdx xx.QuoteResponseLevel
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteOrderQtyData dest) nextFreeIdx xx.OrderQtyData    // component option
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteSettlDate2 dest) nextFreeIdx xx.SettlDate2
    let nextFreeIdx = Option.fold (WriteOrderQty2 dest) nextFreeIdx xx.OrderQty2
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:Quote_NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteQuote_NoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.Quote_NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteBidPx dest) nextFreeIdx xx.BidPx
    let nextFreeIdx = Option.fold (WriteOfferPx dest) nextFreeIdx xx.OfferPx
    let nextFreeIdx = Option.fold (WriteMktBidPx dest) nextFreeIdx xx.MktBidPx
    let nextFreeIdx = Option.fold (WriteMktOfferPx dest) nextFreeIdx xx.MktOfferPx
    let nextFreeIdx = Option.fold (WriteMinBidSize dest) nextFreeIdx xx.MinBidSize
    let nextFreeIdx = Option.fold (WriteBidSize dest) nextFreeIdx xx.BidSize
    let nextFreeIdx = Option.fold (WriteMinOfferSize dest) nextFreeIdx xx.MinOfferSize
    let nextFreeIdx = Option.fold (WriteOfferSize dest) nextFreeIdx xx.OfferSize
    let nextFreeIdx = Option.fold (WriteValidUntilTime dest) nextFreeIdx xx.ValidUntilTime
    let nextFreeIdx = Option.fold (WriteBidSpotRate dest) nextFreeIdx xx.BidSpotRate
    let nextFreeIdx = Option.fold (WriteOfferSpotRate dest) nextFreeIdx xx.OfferSpotRate
    let nextFreeIdx = Option.fold (WriteBidForwardPoints dest) nextFreeIdx xx.BidForwardPoints
    let nextFreeIdx = Option.fold (WriteOfferForwardPoints dest) nextFreeIdx xx.OfferForwardPoints
    let nextFreeIdx = Option.fold (WriteMidPx dest) nextFreeIdx xx.MidPx
    let nextFreeIdx = Option.fold (WriteBidYield dest) nextFreeIdx xx.BidYield
    let nextFreeIdx = Option.fold (WriteMidYield dest) nextFreeIdx xx.MidYield
    let nextFreeIdx = Option.fold (WriteOfferYield dest) nextFreeIdx xx.OfferYield
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteOrdType dest) nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WriteBidForwardPoints2 dest) nextFreeIdx xx.BidForwardPoints2
    let nextFreeIdx = Option.fold (WriteOfferForwardPoints2 dest) nextFreeIdx xx.OfferForwardPoints2
    let nextFreeIdx = Option.fold (WriteSettlCurrBidFxRate dest) nextFreeIdx xx.SettlCurrBidFxRate
    let nextFreeIdx = Option.fold (WriteSettlCurrOfferFxRate dest) nextFreeIdx xx.SettlCurrOfferFxRate
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRateCalc dest) nextFreeIdx xx.SettlCurrFxRateCalc
    let nextFreeIdx = Option.fold (WriteCommType dest) nextFreeIdx xx.CommType
    let nextFreeIdx = Option.fold (WriteCommission dest) nextFreeIdx xx.Commission
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteExDestination dest) nextFreeIdx xx.ExDestination
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: Z
let WriteQuoteCancel (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:QuoteCancel) = 
    let nextFreeIdx = Option.fold (WriteQuoteReqID dest) nextFreeIdx xx.QuoteReqID
    let nextFreeIdx = WriteQuoteID dest nextFreeIdx xx.QuoteID
    let nextFreeIdx = WriteQuoteCancelType dest nextFreeIdx xx.QuoteCancelType
    let nextFreeIdx = Option.fold (WriteQuoteResponseLevel dest) nextFreeIdx xx.QuoteResponseLevel
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoQuoteEntriesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoQuoteEntries dest innerNextFreeIdx (Fix44.Fields.NoQuoteEntries numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoQuoteEntriesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoQuoteEntriesGrp  // end Option.fold
    nextFreeIdx


// tag: a
let WriteQuoteStatusRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:QuoteStatusRequest) = 
    let nextFreeIdx = Option.fold (WriteQuoteStatusReqID dest) nextFreeIdx xx.QuoteStatusReqID
    let nextFreeIdx = Option.fold (WriteQuoteID dest) nextFreeIdx xx.QuoteID
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    nextFreeIdx


// tag: AI
let WriteQuoteStatusReport (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:QuoteStatusReport) = 
    let nextFreeIdx = Option.fold (WriteQuoteStatusReqID dest) nextFreeIdx xx.QuoteStatusReqID
    let nextFreeIdx = Option.fold (WriteQuoteReqID dest) nextFreeIdx xx.QuoteReqID
    let nextFreeIdx = WriteQuoteID dest nextFreeIdx xx.QuoteID
    let nextFreeIdx = Option.fold (WriteQuoteRespID dest) nextFreeIdx xx.QuoteRespID
    let nextFreeIdx = Option.fold (WriteQuoteType dest) nextFreeIdx xx.QuoteType
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteOrderQtyData dest) nextFreeIdx xx.OrderQtyData    // component option
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteSettlDate2 dest) nextFreeIdx xx.SettlDate2
    let nextFreeIdx = Option.fold (WriteOrderQty2 dest) nextFreeIdx xx.OrderQty2
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:QuoteStatusReport_NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteQuoteStatusReport_NoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.QuoteStatusReport_NoLegsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoQuoteQualifiersGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoQuoteQualifiers dest innerNextFreeIdx (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoQuoteQualifiersGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoQuoteQualifiersGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    let nextFreeIdx = Option.fold (WriteBidPx dest) nextFreeIdx xx.BidPx
    let nextFreeIdx = Option.fold (WriteOfferPx dest) nextFreeIdx xx.OfferPx
    let nextFreeIdx = Option.fold (WriteMktBidPx dest) nextFreeIdx xx.MktBidPx
    let nextFreeIdx = Option.fold (WriteMktOfferPx dest) nextFreeIdx xx.MktOfferPx
    let nextFreeIdx = Option.fold (WriteMinBidSize dest) nextFreeIdx xx.MinBidSize
    let nextFreeIdx = Option.fold (WriteBidSize dest) nextFreeIdx xx.BidSize
    let nextFreeIdx = Option.fold (WriteMinOfferSize dest) nextFreeIdx xx.MinOfferSize
    let nextFreeIdx = Option.fold (WriteOfferSize dest) nextFreeIdx xx.OfferSize
    let nextFreeIdx = Option.fold (WriteValidUntilTime dest) nextFreeIdx xx.ValidUntilTime
    let nextFreeIdx = Option.fold (WriteBidSpotRate dest) nextFreeIdx xx.BidSpotRate
    let nextFreeIdx = Option.fold (WriteOfferSpotRate dest) nextFreeIdx xx.OfferSpotRate
    let nextFreeIdx = Option.fold (WriteBidForwardPoints dest) nextFreeIdx xx.BidForwardPoints
    let nextFreeIdx = Option.fold (WriteOfferForwardPoints dest) nextFreeIdx xx.OfferForwardPoints
    let nextFreeIdx = Option.fold (WriteMidPx dest) nextFreeIdx xx.MidPx
    let nextFreeIdx = Option.fold (WriteBidYield dest) nextFreeIdx xx.BidYield
    let nextFreeIdx = Option.fold (WriteMidYield dest) nextFreeIdx xx.MidYield
    let nextFreeIdx = Option.fold (WriteOfferYield dest) nextFreeIdx xx.OfferYield
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteOrdType dest) nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WriteBidForwardPoints2 dest) nextFreeIdx xx.BidForwardPoints2
    let nextFreeIdx = Option.fold (WriteOfferForwardPoints2 dest) nextFreeIdx xx.OfferForwardPoints2
    let nextFreeIdx = Option.fold (WriteSettlCurrBidFxRate dest) nextFreeIdx xx.SettlCurrBidFxRate
    let nextFreeIdx = Option.fold (WriteSettlCurrOfferFxRate dest) nextFreeIdx xx.SettlCurrOfferFxRate
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRateCalc dest) nextFreeIdx xx.SettlCurrFxRateCalc
    let nextFreeIdx = Option.fold (WriteCommType dest) nextFreeIdx xx.CommType
    let nextFreeIdx = Option.fold (WriteCommission dest) nextFreeIdx xx.Commission
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteExDestination dest) nextFreeIdx xx.ExDestination
    let nextFreeIdx = Option.fold (WriteQuoteStatus dest) nextFreeIdx xx.QuoteStatus
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: i
let WriteMassQuote (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:MassQuote) = 
    let nextFreeIdx = Option.fold (WriteQuoteReqID dest) nextFreeIdx xx.QuoteReqID
    let nextFreeIdx = WriteQuoteID dest nextFreeIdx xx.QuoteID
    let nextFreeIdx = Option.fold (WriteQuoteType dest) nextFreeIdx xx.QuoteType
    let nextFreeIdx = Option.fold (WriteQuoteResponseLevel dest) nextFreeIdx xx.QuoteResponseLevel
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteDefBidSize dest) nextFreeIdx xx.DefBidSize
    let nextFreeIdx = Option.fold (WriteDefOfferSize dest) nextFreeIdx xx.DefOfferSize
    let numGrps = xx.NoQuoteSetsGrp.Length
    let nextFreeIdx = WriteNoQuoteSets dest nextFreeIdx (Fix44.Fields.NoQuoteSets numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NoQuoteSetsGrp |> List.fold (fun accFreeIdx gg -> WriteNoQuoteSetsGrp dest accFreeIdx gg) nextFreeIdx
    nextFreeIdx


// tag: b
let WriteMassQuoteAcknowledgement (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:MassQuoteAcknowledgement) = 
    let nextFreeIdx = Option.fold (WriteQuoteReqID dest) nextFreeIdx xx.QuoteReqID
    let nextFreeIdx = Option.fold (WriteQuoteID dest) nextFreeIdx xx.QuoteID
    let nextFreeIdx = WriteQuoteStatus dest nextFreeIdx xx.QuoteStatus
    let nextFreeIdx = Option.fold (WriteQuoteRejectReason dest) nextFreeIdx xx.QuoteRejectReason
    let nextFreeIdx = Option.fold (WriteQuoteResponseLevel dest) nextFreeIdx xx.QuoteResponseLevel
    let nextFreeIdx = Option.fold (WriteQuoteType dest) nextFreeIdx xx.QuoteType
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:MassQuoteAcknowledgement_NoQuoteSetsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoQuoteSets dest innerNextFreeIdx (Fix44.Fields.NoQuoteSets numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteMassQuoteAcknowledgement_NoQuoteSetsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.MassQuoteAcknowledgement_NoQuoteSetsGrp  // end Option.fold
    nextFreeIdx


// tag: V
let WriteMarketDataRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:MarketDataRequest) = 
    let nextFreeIdx = WriteMDReqID dest nextFreeIdx xx.MDReqID
    let nextFreeIdx = WriteSubscriptionRequestType dest nextFreeIdx xx.SubscriptionRequestType
    let nextFreeIdx = WriteMarketDepth dest nextFreeIdx xx.MarketDepth
    let nextFreeIdx = Option.fold (WriteMDUpdateType dest) nextFreeIdx xx.MDUpdateType
    let nextFreeIdx = Option.fold (WriteAggregatedBook dest) nextFreeIdx xx.AggregatedBook
    let nextFreeIdx = Option.fold (WriteOpenCloseSettlFlag dest) nextFreeIdx xx.OpenCloseSettlFlag
    let nextFreeIdx = Option.fold (WriteScope dest) nextFreeIdx xx.Scope
    let nextFreeIdx = Option.fold (WriteMDImplicitDelete dest) nextFreeIdx xx.MDImplicitDelete
    let numGrps = xx.NoMDEntryTypesGrp.Length
    let nextFreeIdx = WriteNoMDEntryTypes dest nextFreeIdx (Fix44.Fields.NoMDEntryTypes numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NoMDEntryTypesGrp |> List.fold (fun accFreeIdx gg -> WriteNoMDEntryTypesGrp dest accFreeIdx gg) nextFreeIdx
    let numGrps = xx.MarketDataRequest_NoRelatedSymGrp.Length
    let nextFreeIdx = WriteNoRelatedSym dest nextFreeIdx (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.MarketDataRequest_NoRelatedSymGrp |> List.fold (fun accFreeIdx gg -> WriteMarketDataRequest_NoRelatedSymGrp dest accFreeIdx gg) nextFreeIdx
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradingSessionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTradingSessions dest innerNextFreeIdx (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradingSessionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradingSessionsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteApplQueueAction dest) nextFreeIdx xx.ApplQueueAction
    let nextFreeIdx = Option.fold (WriteApplQueueMax dest) nextFreeIdx xx.ApplQueueMax
    nextFreeIdx


// tag: W
let WriteMarketDataSnapshotFullRefresh (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:MarketDataSnapshotFullRefresh) = 
    let nextFreeIdx = Option.fold (WriteMDReqID dest) nextFreeIdx xx.MDReqID
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteFinancialStatus dest) nextFreeIdx xx.FinancialStatus
    let nextFreeIdx = Option.fold (WriteCorporateAction dest) nextFreeIdx xx.CorporateAction
    let nextFreeIdx = Option.fold (WriteNetChgPrevDay dest) nextFreeIdx xx.NetChgPrevDay
    let numGrps = xx.NoMDEntriesGrp.Length
    let nextFreeIdx = WriteNoMDEntries dest nextFreeIdx (Fix44.Fields.NoMDEntries numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NoMDEntriesGrp |> List.fold (fun accFreeIdx gg -> WriteNoMDEntriesGrp dest accFreeIdx gg) nextFreeIdx
    let nextFreeIdx = Option.fold (WriteApplQueueDepth dest) nextFreeIdx xx.ApplQueueDepth
    let nextFreeIdx = Option.fold (WriteApplQueueResolution dest) nextFreeIdx xx.ApplQueueResolution
    nextFreeIdx


// tag: X
let WriteMarketDataIncrementalRefresh (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:MarketDataIncrementalRefresh) = 
    let nextFreeIdx = Option.fold (WriteMDReqID dest) nextFreeIdx xx.MDReqID
    let numGrps = xx.MarketDataIncrementalRefresh_NoMDEntriesGrp.Length
    let nextFreeIdx = WriteNoMDEntries dest nextFreeIdx (Fix44.Fields.NoMDEntries numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.MarketDataIncrementalRefresh_NoMDEntriesGrp |> List.fold (fun accFreeIdx gg -> WriteMarketDataIncrementalRefresh_NoMDEntriesGrp dest accFreeIdx gg) nextFreeIdx
    let nextFreeIdx = Option.fold (WriteApplQueueDepth dest) nextFreeIdx xx.ApplQueueDepth
    let nextFreeIdx = Option.fold (WriteApplQueueResolution dest) nextFreeIdx xx.ApplQueueResolution
    nextFreeIdx


// tag: Y
let WriteMarketDataRequestReject (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:MarketDataRequestReject) = 
    let nextFreeIdx = WriteMDReqID dest nextFreeIdx xx.MDReqID
    let nextFreeIdx = Option.fold (WriteMDReqRejReason dest) nextFreeIdx xx.MDReqRejReason
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoAltMDSourceGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAltMDSource dest innerNextFreeIdx (Fix44.Fields.NoAltMDSource numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoAltMDSourceGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoAltMDSourceGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: c
let WriteSecurityDefinitionRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:SecurityDefinitionRequest) = 
    let nextFreeIdx = WriteSecurityReqID dest nextFreeIdx xx.SecurityReqID
    let nextFreeIdx = WriteSecurityRequestType dest nextFreeIdx xx.SecurityRequestType
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteInstrumentExtension dest) nextFreeIdx xx.InstrumentExtension    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteExpirationCycle dest) nextFreeIdx xx.ExpirationCycle
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    nextFreeIdx


// tag: d
let WriteSecurityDefinition (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:SecurityDefinition) = 
    let nextFreeIdx = WriteSecurityReqID dest nextFreeIdx xx.SecurityReqID
    let nextFreeIdx = WriteSecurityResponseID dest nextFreeIdx xx.SecurityResponseID
    let nextFreeIdx = WriteSecurityResponseType dest nextFreeIdx xx.SecurityResponseType
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteInstrumentExtension dest) nextFreeIdx xx.InstrumentExtension    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteExpirationCycle dest) nextFreeIdx xx.ExpirationCycle
    let nextFreeIdx = Option.fold (WriteRoundLot dest) nextFreeIdx xx.RoundLot
    let nextFreeIdx = Option.fold (WriteMinTradeVol dest) nextFreeIdx xx.MinTradeVol
    nextFreeIdx


// tag: v
let WriteSecurityTypeRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:SecurityTypeRequest) = 
    let nextFreeIdx = WriteSecurityReqID dest nextFreeIdx xx.SecurityReqID
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteProduct dest) nextFreeIdx xx.Product
    let nextFreeIdx = Option.fold (WriteSecurityType dest) nextFreeIdx xx.SecurityType
    let nextFreeIdx = Option.fold (WriteSecuritySubType dest) nextFreeIdx xx.SecuritySubType
    nextFreeIdx


// tag: w
let WriteSecurityTypes (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:SecurityTypes) = 
    let nextFreeIdx = WriteSecurityReqID dest nextFreeIdx xx.SecurityReqID
    let nextFreeIdx = WriteSecurityResponseID dest nextFreeIdx xx.SecurityResponseID
    let nextFreeIdx = WriteSecurityResponseType dest nextFreeIdx xx.SecurityResponseType
    let nextFreeIdx = Option.fold (WriteTotNoSecurityTypes dest) nextFreeIdx xx.TotNoSecurityTypes
    let nextFreeIdx = Option.fold (WriteLastFragment dest) nextFreeIdx xx.LastFragment
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoSecurityTypesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoSecurityTypes dest innerNextFreeIdx (Fix44.Fields.NoSecurityTypes numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoSecurityTypesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoSecurityTypesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    nextFreeIdx


// tag: x
let WriteSecurityListRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:SecurityListRequest) = 
    let nextFreeIdx = WriteSecurityReqID dest nextFreeIdx xx.SecurityReqID
    let nextFreeIdx = WriteSecurityListRequestType dest nextFreeIdx xx.SecurityListRequestType
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteInstrumentExtension dest) nextFreeIdx xx.InstrumentExtension    // component option
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    nextFreeIdx


// tag: y
let WriteSecurityList (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:SecurityList) = 
    let nextFreeIdx = WriteSecurityReqID dest nextFreeIdx xx.SecurityReqID
    let nextFreeIdx = WriteSecurityResponseID dest nextFreeIdx xx.SecurityResponseID
    let nextFreeIdx = WriteSecurityRequestResult dest nextFreeIdx xx.SecurityRequestResult
    let nextFreeIdx = Option.fold (WriteTotNoRelatedSym dest) nextFreeIdx xx.TotNoRelatedSym
    let nextFreeIdx = Option.fold (WriteLastFragment dest) nextFreeIdx xx.LastFragment
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:SecurityList_NoRelatedSymGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoRelatedSym dest innerNextFreeIdx (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteSecurityList_NoRelatedSymGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.SecurityList_NoRelatedSymGrp  // end Option.fold
    nextFreeIdx


// tag: z
let WriteDerivativeSecurityListRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:DerivativeSecurityListRequest) = 
    let nextFreeIdx = WriteSecurityReqID dest nextFreeIdx xx.SecurityReqID
    let nextFreeIdx = WriteSecurityListRequestType dest nextFreeIdx xx.SecurityListRequestType
    let nextFreeIdx = Option.fold (WriteUnderlyingInstrument dest) nextFreeIdx xx.UnderlyingInstrument    // component option
    let nextFreeIdx = Option.fold (WriteSecuritySubType dest) nextFreeIdx xx.SecuritySubType
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    nextFreeIdx


// tag: AA
let WriteDerivativeSecurityList (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:DerivativeSecurityList) = 
    let nextFreeIdx = WriteSecurityReqID dest nextFreeIdx xx.SecurityReqID
    let nextFreeIdx = WriteSecurityResponseID dest nextFreeIdx xx.SecurityResponseID
    let nextFreeIdx = WriteSecurityRequestResult dest nextFreeIdx xx.SecurityRequestResult
    let nextFreeIdx = Option.fold (WriteUnderlyingInstrument dest) nextFreeIdx xx.UnderlyingInstrument    // component option
    let nextFreeIdx = Option.fold (WriteTotNoRelatedSym dest) nextFreeIdx xx.TotNoRelatedSym
    let nextFreeIdx = Option.fold (WriteLastFragment dest) nextFreeIdx xx.LastFragment
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:DerivativeSecurityList_NoRelatedSymGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoRelatedSym dest innerNextFreeIdx (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteDerivativeSecurityList_NoRelatedSymGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.DerivativeSecurityList_NoRelatedSymGrp  // end Option.fold
    nextFreeIdx


// tag: e
let WriteSecurityStatusRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:SecurityStatusRequest) = 
    let nextFreeIdx = WriteSecurityStatusReqID dest nextFreeIdx xx.SecurityStatusReqID
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteInstrumentExtension dest) nextFreeIdx xx.InstrumentExtension    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = WriteSubscriptionRequestType dest nextFreeIdx xx.SubscriptionRequestType
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    nextFreeIdx


// tag: f
let WriteSecurityStatus (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:SecurityStatus) = 
    let nextFreeIdx = Option.fold (WriteSecurityStatusReqID dest) nextFreeIdx xx.SecurityStatusReqID
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteInstrumentExtension dest) nextFreeIdx xx.InstrumentExtension    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteUnsolicitedIndicator dest) nextFreeIdx xx.UnsolicitedIndicator
    let nextFreeIdx = Option.fold (WriteSecurityTradingStatus dest) nextFreeIdx xx.SecurityTradingStatus
    let nextFreeIdx = Option.fold (WriteFinancialStatus dest) nextFreeIdx xx.FinancialStatus
    let nextFreeIdx = Option.fold (WriteCorporateAction dest) nextFreeIdx xx.CorporateAction
    let nextFreeIdx = Option.fold (WriteHaltReason dest) nextFreeIdx xx.HaltReason
    let nextFreeIdx = Option.fold (WriteInViewOfCommon dest) nextFreeIdx xx.InViewOfCommon
    let nextFreeIdx = Option.fold (WriteDueToRelated dest) nextFreeIdx xx.DueToRelated
    let nextFreeIdx = Option.fold (WriteBuyVolume dest) nextFreeIdx xx.BuyVolume
    let nextFreeIdx = Option.fold (WriteSellVolume dest) nextFreeIdx xx.SellVolume
    let nextFreeIdx = Option.fold (WriteHighPx dest) nextFreeIdx xx.HighPx
    let nextFreeIdx = Option.fold (WriteLowPx dest) nextFreeIdx xx.LowPx
    let nextFreeIdx = Option.fold (WriteLastPx dest) nextFreeIdx xx.LastPx
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteAdjustment dest) nextFreeIdx xx.Adjustment
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: g
let WriteTradingSessionStatusRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:TradingSessionStatusRequest) = 
    let nextFreeIdx = WriteTradSesReqID dest nextFreeIdx xx.TradSesReqID
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteTradSesMethod dest) nextFreeIdx xx.TradSesMethod
    let nextFreeIdx = Option.fold (WriteTradSesMode dest) nextFreeIdx xx.TradSesMode
    let nextFreeIdx = WriteSubscriptionRequestType dest nextFreeIdx xx.SubscriptionRequestType
    nextFreeIdx


// tag: h
let WriteTradingSessionStatus (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:TradingSessionStatus) = 
    let nextFreeIdx = Option.fold (WriteTradSesReqID dest) nextFreeIdx xx.TradSesReqID
    let nextFreeIdx = WriteTradingSessionID dest nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteTradSesMethod dest) nextFreeIdx xx.TradSesMethod
    let nextFreeIdx = Option.fold (WriteTradSesMode dest) nextFreeIdx xx.TradSesMode
    let nextFreeIdx = Option.fold (WriteUnsolicitedIndicator dest) nextFreeIdx xx.UnsolicitedIndicator
    let nextFreeIdx = WriteTradSesStatus dest nextFreeIdx xx.TradSesStatus
    let nextFreeIdx = Option.fold (WriteTradSesStatusRejReason dest) nextFreeIdx xx.TradSesStatusRejReason
    let nextFreeIdx = Option.fold (WriteTradSesStartTime dest) nextFreeIdx xx.TradSesStartTime
    let nextFreeIdx = Option.fold (WriteTradSesOpenTime dest) nextFreeIdx xx.TradSesOpenTime
    let nextFreeIdx = Option.fold (WriteTradSesPreCloseTime dest) nextFreeIdx xx.TradSesPreCloseTime
    let nextFreeIdx = Option.fold (WriteTradSesCloseTime dest) nextFreeIdx xx.TradSesCloseTime
    let nextFreeIdx = Option.fold (WriteTradSesEndTime dest) nextFreeIdx xx.TradSesEndTime
    let nextFreeIdx = Option.fold (WriteTotalVolumeTraded dest) nextFreeIdx xx.TotalVolumeTraded
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: D
let WriteNewOrderSingle (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:NewOrderSingle) = 
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteClOrdLinkID dest) nextFreeIdx xx.ClOrdLinkID
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteDayBookingInst dest) nextFreeIdx xx.DayBookingInst
    let nextFreeIdx = Option.fold (WriteBookingUnit dest) nextFreeIdx xx.BookingUnit
    let nextFreeIdx = Option.fold (WritePreallocMethod dest) nextFreeIdx xx.PreallocMethod
    let nextFreeIdx = Option.fold (WriteAllocID dest) nextFreeIdx xx.AllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAllocs dest innerNextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoAllocsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteCashMargin dest) nextFreeIdx xx.CashMargin
    let nextFreeIdx = Option.fold (WriteClearingFeeIndicator dest) nextFreeIdx xx.ClearingFeeIndicator
    let nextFreeIdx = Option.fold (WriteHandlInst dest) nextFreeIdx xx.HandlInst
    let nextFreeIdx = Option.fold (WriteExecInst dest) nextFreeIdx xx.ExecInst
    let nextFreeIdx = Option.fold (WriteMinQty dest) nextFreeIdx xx.MinQty
    let nextFreeIdx = Option.fold (WriteMaxFloor dest) nextFreeIdx xx.MaxFloor
    let nextFreeIdx = Option.fold (WriteExDestination dest) nextFreeIdx xx.ExDestination
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradingSessionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTradingSessions dest innerNextFreeIdx (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradingSessionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradingSessionsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteProcessCode dest) nextFreeIdx xx.ProcessCode
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePrevClosePx dest) nextFreeIdx xx.PrevClosePx
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteLocateReqd dest) nextFreeIdx xx.LocateReqd
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = WriteOrderQtyData dest nextFreeIdx xx.OrderQtyData   // component
    let nextFreeIdx = WriteOrdType dest nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WriteStopPx dest) nextFreeIdx xx.StopPx
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteComplianceID dest) nextFreeIdx xx.ComplianceID
    let nextFreeIdx = Option.fold (WriteSolicitedFlag dest) nextFreeIdx xx.SolicitedFlag
    let nextFreeIdx = Option.fold (WriteIOIid dest) nextFreeIdx xx.IOIid
    let nextFreeIdx = Option.fold (WriteQuoteID dest) nextFreeIdx xx.QuoteID
    let nextFreeIdx = Option.fold (WriteTimeInForce dest) nextFreeIdx xx.TimeInForce
    let nextFreeIdx = Option.fold (WriteEffectiveTime dest) nextFreeIdx xx.EffectiveTime
    let nextFreeIdx = Option.fold (WriteExpireDate dest) nextFreeIdx xx.ExpireDate
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteGTBookingInst dest) nextFreeIdx xx.GTBookingInst
    let nextFreeIdx = Option.fold (WriteCommissionData dest) nextFreeIdx xx.CommissionData    // component option
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WriteOrderRestrictions dest) nextFreeIdx xx.OrderRestrictions
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteForexReq dest) nextFreeIdx xx.ForexReq
    let nextFreeIdx = Option.fold (WriteSettlCurrency dest) nextFreeIdx xx.SettlCurrency
    let nextFreeIdx = Option.fold (WriteBookingType dest) nextFreeIdx xx.BookingType
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteSettlDate2 dest) nextFreeIdx xx.SettlDate2
    let nextFreeIdx = Option.fold (WriteOrderQty2 dest) nextFreeIdx xx.OrderQty2
    let nextFreeIdx = Option.fold (WritePrice2 dest) nextFreeIdx xx.Price2
    let nextFreeIdx = Option.fold (WritePositionEffect dest) nextFreeIdx xx.PositionEffect
    let nextFreeIdx = Option.fold (WriteCoveredOrUncovered dest) nextFreeIdx xx.CoveredOrUncovered
    let nextFreeIdx = Option.fold (WriteMaxShow dest) nextFreeIdx xx.MaxShow
    let nextFreeIdx = Option.fold (WritePegInstructions dest) nextFreeIdx xx.PegInstructions    // component option
    let nextFreeIdx = Option.fold (WriteDiscretionInstructions dest) nextFreeIdx xx.DiscretionInstructions    // component option
    let nextFreeIdx = Option.fold (WriteTargetStrategy dest) nextFreeIdx xx.TargetStrategy
    let nextFreeIdx = Option.fold (WriteTargetStrategyParameters dest) nextFreeIdx xx.TargetStrategyParameters
    let nextFreeIdx = Option.fold (WriteParticipationRate dest) nextFreeIdx xx.ParticipationRate
    let nextFreeIdx = Option.fold (WriteCancellationRights dest) nextFreeIdx xx.CancellationRights
    let nextFreeIdx = Option.fold (WriteMoneyLaunderingStatus dest) nextFreeIdx xx.MoneyLaunderingStatus
    let nextFreeIdx = Option.fold (WriteRegistID dest) nextFreeIdx xx.RegistID
    let nextFreeIdx = Option.fold (WriteDesignation dest) nextFreeIdx xx.Designation
    nextFreeIdx


// tag: 8
let WriteExecutionReport (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:ExecutionReport) = 
    let nextFreeIdx = WriteOrderID dest nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteSecondaryOrderID dest) nextFreeIdx xx.SecondaryOrderID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryExecID dest) nextFreeIdx xx.SecondaryExecID
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteOrigClOrdID dest) nextFreeIdx xx.OrigClOrdID
    let nextFreeIdx = Option.fold (WriteClOrdLinkID dest) nextFreeIdx xx.ClOrdLinkID
    let nextFreeIdx = Option.fold (WriteQuoteRespID dest) nextFreeIdx xx.QuoteRespID
    let nextFreeIdx = Option.fold (WriteOrdStatusReqID dest) nextFreeIdx xx.OrdStatusReqID
    let nextFreeIdx = Option.fold (WriteMassStatusReqID dest) nextFreeIdx xx.MassStatusReqID
    let nextFreeIdx = Option.fold (WriteTotNumReports dest) nextFreeIdx xx.TotNumReports
    let nextFreeIdx = Option.fold (WriteLastRptRequested dest) nextFreeIdx xx.LastRptRequested
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoContraBrokersGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoContraBrokers dest innerNextFreeIdx (Fix44.Fields.NoContraBrokers numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoContraBrokersGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoContraBrokersGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteListID dest) nextFreeIdx xx.ListID
    let nextFreeIdx = Option.fold (WriteCrossID dest) nextFreeIdx xx.CrossID
    let nextFreeIdx = Option.fold (WriteOrigCrossID dest) nextFreeIdx xx.OrigCrossID
    let nextFreeIdx = Option.fold (WriteCrossType dest) nextFreeIdx xx.CrossType
    let nextFreeIdx = WriteExecID dest nextFreeIdx xx.ExecID
    let nextFreeIdx = Option.fold (WriteExecRefID dest) nextFreeIdx xx.ExecRefID
    let nextFreeIdx = WriteExecType dest nextFreeIdx xx.ExecType
    let nextFreeIdx = WriteOrdStatus dest nextFreeIdx xx.OrdStatus
    let nextFreeIdx = Option.fold (WriteWorkingIndicator dest) nextFreeIdx xx.WorkingIndicator
    let nextFreeIdx = Option.fold (WriteOrdRejReason dest) nextFreeIdx xx.OrdRejReason
    let nextFreeIdx = Option.fold (WriteExecRestatementReason dest) nextFreeIdx xx.ExecRestatementReason
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteDayBookingInst dest) nextFreeIdx xx.DayBookingInst
    let nextFreeIdx = Option.fold (WriteBookingUnit dest) nextFreeIdx xx.BookingUnit
    let nextFreeIdx = Option.fold (WritePreallocMethod dest) nextFreeIdx xx.PreallocMethod
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteCashMargin dest) nextFreeIdx xx.CashMargin
    let nextFreeIdx = Option.fold (WriteClearingFeeIndicator dest) nextFreeIdx xx.ClearingFeeIndicator
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = Option.fold (WriteOrderQtyData dest) nextFreeIdx xx.OrderQtyData    // component option
    let nextFreeIdx = Option.fold (WriteOrdType dest) nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WriteStopPx dest) nextFreeIdx xx.StopPx
    let nextFreeIdx = Option.fold (WritePegInstructions dest) nextFreeIdx xx.PegInstructions    // component option
    let nextFreeIdx = Option.fold (WriteDiscretionInstructions dest) nextFreeIdx xx.DiscretionInstructions    // component option
    let nextFreeIdx = Option.fold (WritePeggedPrice dest) nextFreeIdx xx.PeggedPrice
    let nextFreeIdx = Option.fold (WriteDiscretionPrice dest) nextFreeIdx xx.DiscretionPrice
    let nextFreeIdx = Option.fold (WriteTargetStrategy dest) nextFreeIdx xx.TargetStrategy
    let nextFreeIdx = Option.fold (WriteTargetStrategyParameters dest) nextFreeIdx xx.TargetStrategyParameters
    let nextFreeIdx = Option.fold (WriteParticipationRate dest) nextFreeIdx xx.ParticipationRate
    let nextFreeIdx = Option.fold (WriteTargetStrategyPerformance dest) nextFreeIdx xx.TargetStrategyPerformance
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteComplianceID dest) nextFreeIdx xx.ComplianceID
    let nextFreeIdx = Option.fold (WriteSolicitedFlag dest) nextFreeIdx xx.SolicitedFlag
    let nextFreeIdx = Option.fold (WriteTimeInForce dest) nextFreeIdx xx.TimeInForce
    let nextFreeIdx = Option.fold (WriteEffectiveTime dest) nextFreeIdx xx.EffectiveTime
    let nextFreeIdx = Option.fold (WriteExpireDate dest) nextFreeIdx xx.ExpireDate
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteExecInst dest) nextFreeIdx xx.ExecInst
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WriteOrderRestrictions dest) nextFreeIdx xx.OrderRestrictions
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteLastQty dest) nextFreeIdx xx.LastQty
    let nextFreeIdx = Option.fold (WriteUnderlyingLastQty dest) nextFreeIdx xx.UnderlyingLastQty
    let nextFreeIdx = Option.fold (WriteLastPx dest) nextFreeIdx xx.LastPx
    let nextFreeIdx = Option.fold (WriteUnderlyingLastPx dest) nextFreeIdx xx.UnderlyingLastPx
    let nextFreeIdx = Option.fold (WriteLastParPx dest) nextFreeIdx xx.LastParPx
    let nextFreeIdx = Option.fold (WriteLastSpotRate dest) nextFreeIdx xx.LastSpotRate
    let nextFreeIdx = Option.fold (WriteLastForwardPoints dest) nextFreeIdx xx.LastForwardPoints
    let nextFreeIdx = Option.fold (WriteLastMkt dest) nextFreeIdx xx.LastMkt
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteTimeBracket dest) nextFreeIdx xx.TimeBracket
    let nextFreeIdx = Option.fold (WriteLastCapacity dest) nextFreeIdx xx.LastCapacity
    let nextFreeIdx = WriteLeavesQty dest nextFreeIdx xx.LeavesQty
    let nextFreeIdx = WriteCumQty dest nextFreeIdx xx.CumQty
    let nextFreeIdx = WriteAvgPx dest nextFreeIdx xx.AvgPx
    let nextFreeIdx = Option.fold (WriteDayOrderQty dest) nextFreeIdx xx.DayOrderQty
    let nextFreeIdx = Option.fold (WriteDayCumQty dest) nextFreeIdx xx.DayCumQty
    let nextFreeIdx = Option.fold (WriteDayAvgPx dest) nextFreeIdx xx.DayAvgPx
    let nextFreeIdx = Option.fold (WriteGTBookingInst dest) nextFreeIdx xx.GTBookingInst
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteReportToExch dest) nextFreeIdx xx.ReportToExch
    let nextFreeIdx = Option.fold (WriteCommissionData dest) nextFreeIdx xx.CommissionData    // component option
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    let nextFreeIdx = Option.fold (WriteGrossTradeAmt dest) nextFreeIdx xx.GrossTradeAmt
    let nextFreeIdx = Option.fold (WriteNumDaysInterest dest) nextFreeIdx xx.NumDaysInterest
    let nextFreeIdx = Option.fold (WriteExDate dest) nextFreeIdx xx.ExDate
    let nextFreeIdx = Option.fold (WriteAccruedInterestRate dest) nextFreeIdx xx.AccruedInterestRate
    let nextFreeIdx = Option.fold (WriteAccruedInterestAmt dest) nextFreeIdx xx.AccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteInterestAtMaturity dest) nextFreeIdx xx.InterestAtMaturity
    let nextFreeIdx = Option.fold (WriteEndAccruedInterestAmt dest) nextFreeIdx xx.EndAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteStartCash dest) nextFreeIdx xx.StartCash
    let nextFreeIdx = Option.fold (WriteEndCash dest) nextFreeIdx xx.EndCash
    let nextFreeIdx = Option.fold (WriteTradedFlatSwitch dest) nextFreeIdx xx.TradedFlatSwitch
    let nextFreeIdx = Option.fold (WriteBasisFeatureDate dest) nextFreeIdx xx.BasisFeatureDate
    let nextFreeIdx = Option.fold (WriteBasisFeaturePrice dest) nextFreeIdx xx.BasisFeaturePrice
    let nextFreeIdx = Option.fold (WriteConcession dest) nextFreeIdx xx.Concession
    let nextFreeIdx = Option.fold (WriteTotalTakedown dest) nextFreeIdx xx.TotalTakedown
    let nextFreeIdx = Option.fold (WriteNetMoney dest) nextFreeIdx xx.NetMoney
    let nextFreeIdx = Option.fold (WriteSettlCurrAmt dest) nextFreeIdx xx.SettlCurrAmt
    let nextFreeIdx = Option.fold (WriteSettlCurrency dest) nextFreeIdx xx.SettlCurrency
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRate dest) nextFreeIdx xx.SettlCurrFxRate
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRateCalc dest) nextFreeIdx xx.SettlCurrFxRateCalc
    let nextFreeIdx = Option.fold (WriteHandlInst dest) nextFreeIdx xx.HandlInst
    let nextFreeIdx = Option.fold (WriteMinQty dest) nextFreeIdx xx.MinQty
    let nextFreeIdx = Option.fold (WriteMaxFloor dest) nextFreeIdx xx.MaxFloor
    let nextFreeIdx = Option.fold (WritePositionEffect dest) nextFreeIdx xx.PositionEffect
    let nextFreeIdx = Option.fold (WriteMaxShow dest) nextFreeIdx xx.MaxShow
    let nextFreeIdx = Option.fold (WriteBookingType dest) nextFreeIdx xx.BookingType
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteSettlDate2 dest) nextFreeIdx xx.SettlDate2
    let nextFreeIdx = Option.fold (WriteOrderQty2 dest) nextFreeIdx xx.OrderQty2
    let nextFreeIdx = Option.fold (WriteLastForwardPoints2 dest) nextFreeIdx xx.LastForwardPoints2
    let nextFreeIdx = Option.fold (WriteMultiLegReportingType dest) nextFreeIdx xx.MultiLegReportingType
    let nextFreeIdx = Option.fold (WriteCancellationRights dest) nextFreeIdx xx.CancellationRights
    let nextFreeIdx = Option.fold (WriteMoneyLaunderingStatus dest) nextFreeIdx xx.MoneyLaunderingStatus
    let nextFreeIdx = Option.fold (WriteRegistID dest) nextFreeIdx xx.RegistID
    let nextFreeIdx = Option.fold (WriteDesignation dest) nextFreeIdx xx.Designation
    let nextFreeIdx = Option.fold (WriteTransBkdTime dest) nextFreeIdx xx.TransBkdTime
    let nextFreeIdx = Option.fold (WriteExecValuationPoint dest) nextFreeIdx xx.ExecValuationPoint
    let nextFreeIdx = Option.fold (WriteExecPriceType dest) nextFreeIdx xx.ExecPriceType
    let nextFreeIdx = Option.fold (WriteExecPriceAdjustment dest) nextFreeIdx xx.ExecPriceAdjustment
    let nextFreeIdx = Option.fold (WritePriorityIndicator dest) nextFreeIdx xx.PriorityIndicator
    let nextFreeIdx = Option.fold (WritePriceImprovement dest) nextFreeIdx xx.PriceImprovement
    let nextFreeIdx = Option.fold (WriteLastLiquidityInd dest) nextFreeIdx xx.LastLiquidityInd
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoContAmtsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoContAmts dest innerNextFreeIdx (Fix44.Fields.NoContAmts numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoContAmtsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoContAmtsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:ExecutionReport_NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteExecutionReport_NoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.ExecutionReport_NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteCopyMsgIndicator dest) nextFreeIdx xx.CopyMsgIndicator
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoMiscFeesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoMiscFees dest innerNextFreeIdx (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoMiscFeesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoMiscFeesGrp  // end Option.fold
    nextFreeIdx


// tag: Q
let WriteDontKnowTrade (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:DontKnowTrade) = 
    let nextFreeIdx = WriteOrderID dest nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteSecondaryOrderID dest) nextFreeIdx xx.SecondaryOrderID
    let nextFreeIdx = WriteExecID dest nextFreeIdx xx.ExecID
    let nextFreeIdx = WriteDKReason dest nextFreeIdx xx.DKReason
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = WriteOrderQtyData dest nextFreeIdx xx.OrderQtyData   // component
    let nextFreeIdx = Option.fold (WriteLastQty dest) nextFreeIdx xx.LastQty
    let nextFreeIdx = Option.fold (WriteLastPx dest) nextFreeIdx xx.LastPx
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: G
let WriteOrderCancelReplaceRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:OrderCancelReplaceRequest) = 
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = WriteOrigClOrdID dest nextFreeIdx xx.OrigClOrdID
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteClOrdLinkID dest) nextFreeIdx xx.ClOrdLinkID
    let nextFreeIdx = Option.fold (WriteListID dest) nextFreeIdx xx.ListID
    let nextFreeIdx = Option.fold (WriteOrigOrdModTime dest) nextFreeIdx xx.OrigOrdModTime
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteDayBookingInst dest) nextFreeIdx xx.DayBookingInst
    let nextFreeIdx = Option.fold (WriteBookingUnit dest) nextFreeIdx xx.BookingUnit
    let nextFreeIdx = Option.fold (WritePreallocMethod dest) nextFreeIdx xx.PreallocMethod
    let nextFreeIdx = Option.fold (WriteAllocID dest) nextFreeIdx xx.AllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAllocs dest innerNextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoAllocsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteCashMargin dest) nextFreeIdx xx.CashMargin
    let nextFreeIdx = Option.fold (WriteClearingFeeIndicator dest) nextFreeIdx xx.ClearingFeeIndicator
    let nextFreeIdx = Option.fold (WriteHandlInst dest) nextFreeIdx xx.HandlInst
    let nextFreeIdx = Option.fold (WriteExecInst dest) nextFreeIdx xx.ExecInst
    let nextFreeIdx = Option.fold (WriteMinQty dest) nextFreeIdx xx.MinQty
    let nextFreeIdx = Option.fold (WriteMaxFloor dest) nextFreeIdx xx.MaxFloor
    let nextFreeIdx = Option.fold (WriteExDestination dest) nextFreeIdx xx.ExDestination
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradingSessionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTradingSessions dest innerNextFreeIdx (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradingSessionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradingSessionsGrp  // end Option.fold
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = WriteOrderQtyData dest nextFreeIdx xx.OrderQtyData   // component
    let nextFreeIdx = WriteOrdType dest nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WriteStopPx dest) nextFreeIdx xx.StopPx
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    let nextFreeIdx = Option.fold (WritePegInstructions dest) nextFreeIdx xx.PegInstructions    // component option
    let nextFreeIdx = Option.fold (WriteDiscretionInstructions dest) nextFreeIdx xx.DiscretionInstructions    // component option
    let nextFreeIdx = Option.fold (WriteTargetStrategy dest) nextFreeIdx xx.TargetStrategy
    let nextFreeIdx = Option.fold (WriteTargetStrategyParameters dest) nextFreeIdx xx.TargetStrategyParameters
    let nextFreeIdx = Option.fold (WriteParticipationRate dest) nextFreeIdx xx.ParticipationRate
    let nextFreeIdx = Option.fold (WriteComplianceID dest) nextFreeIdx xx.ComplianceID
    let nextFreeIdx = Option.fold (WriteSolicitedFlag dest) nextFreeIdx xx.SolicitedFlag
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteTimeInForce dest) nextFreeIdx xx.TimeInForce
    let nextFreeIdx = Option.fold (WriteEffectiveTime dest) nextFreeIdx xx.EffectiveTime
    let nextFreeIdx = Option.fold (WriteExpireDate dest) nextFreeIdx xx.ExpireDate
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteGTBookingInst dest) nextFreeIdx xx.GTBookingInst
    let nextFreeIdx = Option.fold (WriteCommissionData dest) nextFreeIdx xx.CommissionData    // component option
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WriteOrderRestrictions dest) nextFreeIdx xx.OrderRestrictions
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteForexReq dest) nextFreeIdx xx.ForexReq
    let nextFreeIdx = Option.fold (WriteSettlCurrency dest) nextFreeIdx xx.SettlCurrency
    let nextFreeIdx = Option.fold (WriteBookingType dest) nextFreeIdx xx.BookingType
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteSettlDate2 dest) nextFreeIdx xx.SettlDate2
    let nextFreeIdx = Option.fold (WriteOrderQty2 dest) nextFreeIdx xx.OrderQty2
    let nextFreeIdx = Option.fold (WritePrice2 dest) nextFreeIdx xx.Price2
    let nextFreeIdx = Option.fold (WritePositionEffect dest) nextFreeIdx xx.PositionEffect
    let nextFreeIdx = Option.fold (WriteCoveredOrUncovered dest) nextFreeIdx xx.CoveredOrUncovered
    let nextFreeIdx = Option.fold (WriteMaxShow dest) nextFreeIdx xx.MaxShow
    let nextFreeIdx = Option.fold (WriteLocateReqd dest) nextFreeIdx xx.LocateReqd
    let nextFreeIdx = Option.fold (WriteCancellationRights dest) nextFreeIdx xx.CancellationRights
    let nextFreeIdx = Option.fold (WriteMoneyLaunderingStatus dest) nextFreeIdx xx.MoneyLaunderingStatus
    let nextFreeIdx = Option.fold (WriteRegistID dest) nextFreeIdx xx.RegistID
    let nextFreeIdx = Option.fold (WriteDesignation dest) nextFreeIdx xx.Designation
    nextFreeIdx


// tag: F
let WriteOrderCancelRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:OrderCancelRequest) = 
    let nextFreeIdx = WriteOrigClOrdID dest nextFreeIdx xx.OrigClOrdID
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteClOrdLinkID dest) nextFreeIdx xx.ClOrdLinkID
    let nextFreeIdx = Option.fold (WriteListID dest) nextFreeIdx xx.ListID
    let nextFreeIdx = Option.fold (WriteOrigOrdModTime dest) nextFreeIdx xx.OrigOrdModTime
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = WriteOrderQtyData dest nextFreeIdx xx.OrderQtyData   // component
    let nextFreeIdx = Option.fold (WriteComplianceID dest) nextFreeIdx xx.ComplianceID
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: 9
let WriteOrderCancelReject (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:OrderCancelReject) = 
    let nextFreeIdx = WriteOrderID dest nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteSecondaryOrderID dest) nextFreeIdx xx.SecondaryOrderID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteClOrdLinkID dest) nextFreeIdx xx.ClOrdLinkID
    let nextFreeIdx = WriteOrigClOrdID dest nextFreeIdx xx.OrigClOrdID
    let nextFreeIdx = WriteOrdStatus dest nextFreeIdx xx.OrdStatus
    let nextFreeIdx = Option.fold (WriteWorkingIndicator dest) nextFreeIdx xx.WorkingIndicator
    let nextFreeIdx = Option.fold (WriteOrigOrdModTime dest) nextFreeIdx xx.OrigOrdModTime
    let nextFreeIdx = Option.fold (WriteListID dest) nextFreeIdx xx.ListID
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = WriteCxlRejResponseTo dest nextFreeIdx xx.CxlRejResponseTo
    let nextFreeIdx = Option.fold (WriteCxlRejReason dest) nextFreeIdx xx.CxlRejReason
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: H
let WriteOrderStatusRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:OrderStatusRequest) = 
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteClOrdLinkID dest) nextFreeIdx xx.ClOrdLinkID
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteOrdStatusReqID dest) nextFreeIdx xx.OrdStatusReqID
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    nextFreeIdx


// tag: q
let WriteOrderMassCancelRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:OrderMassCancelRequest) = 
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = WriteMassCancelRequestType dest nextFreeIdx xx.MassCancelRequestType
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteUnderlyingInstrument dest) nextFreeIdx xx.UnderlyingInstrument    // component option
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: r
let WriteOrderMassCancelReport (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:OrderMassCancelReport) = 
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = WriteOrderID dest nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteSecondaryOrderID dest) nextFreeIdx xx.SecondaryOrderID
    let nextFreeIdx = WriteMassCancelRequestType dest nextFreeIdx xx.MassCancelRequestType
    let nextFreeIdx = WriteMassCancelResponse dest nextFreeIdx xx.MassCancelResponse
    let nextFreeIdx = Option.fold (WriteMassCancelRejectReason dest) nextFreeIdx xx.MassCancelRejectReason
    let nextFreeIdx = Option.fold (WriteTotalAffectedOrders dest) nextFreeIdx xx.TotalAffectedOrders
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoAffectedOrdersGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAffectedOrders dest innerNextFreeIdx (Fix44.Fields.NoAffectedOrders numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoAffectedOrdersGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoAffectedOrdersGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteUnderlyingInstrument dest) nextFreeIdx xx.UnderlyingInstrument    // component option
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AF
let WriteOrderMassStatusRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:OrderMassStatusRequest) = 
    let nextFreeIdx = WriteMassStatusReqID dest nextFreeIdx xx.MassStatusReqID
    let nextFreeIdx = WriteMassStatusReqType dest nextFreeIdx xx.MassStatusReqType
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteUnderlyingInstrument dest) nextFreeIdx xx.UnderlyingInstrument    // component option
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    nextFreeIdx


// tag: s
let WriteNewOrderCross (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:NewOrderCross) = 
    let nextFreeIdx = WriteCrossID dest nextFreeIdx xx.CrossID
    let nextFreeIdx = WriteCrossType dest nextFreeIdx xx.CrossType
    let nextFreeIdx = WriteCrossPrioritization dest nextFreeIdx xx.CrossPrioritization
    let noSidesField =  // ####
        match xx.NoSidesGrp with
        | OneOrTwo.One _ -> NoSides.OneSide
        | OneOrTwo.Two _ -> NoSides.BothSides
    let nextFreeIdx = WriteNoSides dest nextFreeIdx noSidesField
    let nextFreeIdx = xx.NoSidesGrp |> OneOrTwo.fold (WriteNoSidesGrp dest) nextFreeIdx  // group
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteHandlInst dest) nextFreeIdx xx.HandlInst
    let nextFreeIdx = Option.fold (WriteExecInst dest) nextFreeIdx xx.ExecInst
    let nextFreeIdx = Option.fold (WriteMinQty dest) nextFreeIdx xx.MinQty
    let nextFreeIdx = Option.fold (WriteMaxFloor dest) nextFreeIdx xx.MaxFloor
    let nextFreeIdx = Option.fold (WriteExDestination dest) nextFreeIdx xx.ExDestination
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradingSessionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTradingSessions dest innerNextFreeIdx (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradingSessionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradingSessionsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteProcessCode dest) nextFreeIdx xx.ProcessCode
    let nextFreeIdx = Option.fold (WritePrevClosePx dest) nextFreeIdx xx.PrevClosePx
    let nextFreeIdx = Option.fold (WriteLocateReqd dest) nextFreeIdx xx.LocateReqd
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = WriteOrdType dest nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WriteStopPx dest) nextFreeIdx xx.StopPx
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteComplianceID dest) nextFreeIdx xx.ComplianceID
    let nextFreeIdx = Option.fold (WriteIOIid dest) nextFreeIdx xx.IOIid
    let nextFreeIdx = Option.fold (WriteQuoteID dest) nextFreeIdx xx.QuoteID
    let nextFreeIdx = Option.fold (WriteTimeInForce dest) nextFreeIdx xx.TimeInForce
    let nextFreeIdx = Option.fold (WriteEffectiveTime dest) nextFreeIdx xx.EffectiveTime
    let nextFreeIdx = Option.fold (WriteExpireDate dest) nextFreeIdx xx.ExpireDate
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteGTBookingInst dest) nextFreeIdx xx.GTBookingInst
    let nextFreeIdx = Option.fold (WriteMaxShow dest) nextFreeIdx xx.MaxShow
    let nextFreeIdx = Option.fold (WritePegInstructions dest) nextFreeIdx xx.PegInstructions    // component option
    let nextFreeIdx = Option.fold (WriteDiscretionInstructions dest) nextFreeIdx xx.DiscretionInstructions    // component option
    let nextFreeIdx = Option.fold (WriteTargetStrategy dest) nextFreeIdx xx.TargetStrategy
    let nextFreeIdx = Option.fold (WriteTargetStrategyParameters dest) nextFreeIdx xx.TargetStrategyParameters
    let nextFreeIdx = Option.fold (WriteParticipationRate dest) nextFreeIdx xx.ParticipationRate
    let nextFreeIdx = Option.fold (WriteCancellationRights dest) nextFreeIdx xx.CancellationRights
    let nextFreeIdx = Option.fold (WriteMoneyLaunderingStatus dest) nextFreeIdx xx.MoneyLaunderingStatus
    let nextFreeIdx = Option.fold (WriteRegistID dest) nextFreeIdx xx.RegistID
    let nextFreeIdx = Option.fold (WriteDesignation dest) nextFreeIdx xx.Designation
    nextFreeIdx


// tag: t
let WriteCrossOrderCancelReplaceRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:CrossOrderCancelReplaceRequest) = 
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = WriteCrossID dest nextFreeIdx xx.CrossID
    let nextFreeIdx = WriteOrigCrossID dest nextFreeIdx xx.OrigCrossID
    let nextFreeIdx = WriteCrossType dest nextFreeIdx xx.CrossType
    let nextFreeIdx = WriteCrossPrioritization dest nextFreeIdx xx.CrossPrioritization
    let noSidesField =  // ####
        match xx.CrossOrderCancelReplaceRequest_NoSidesGrp with
        | OneOrTwo.One _ -> NoSides.OneSide
        | OneOrTwo.Two _ -> NoSides.BothSides
    let nextFreeIdx = WriteNoSides dest nextFreeIdx noSidesField
    let nextFreeIdx = xx.CrossOrderCancelReplaceRequest_NoSidesGrp |> OneOrTwo.fold (WriteCrossOrderCancelReplaceRequest_NoSidesGrp dest) nextFreeIdx  // group
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteHandlInst dest) nextFreeIdx xx.HandlInst
    let nextFreeIdx = Option.fold (WriteExecInst dest) nextFreeIdx xx.ExecInst
    let nextFreeIdx = Option.fold (WriteMinQty dest) nextFreeIdx xx.MinQty
    let nextFreeIdx = Option.fold (WriteMaxFloor dest) nextFreeIdx xx.MaxFloor
    let nextFreeIdx = Option.fold (WriteExDestination dest) nextFreeIdx xx.ExDestination
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradingSessionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTradingSessions dest innerNextFreeIdx (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradingSessionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradingSessionsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteProcessCode dest) nextFreeIdx xx.ProcessCode
    let nextFreeIdx = Option.fold (WritePrevClosePx dest) nextFreeIdx xx.PrevClosePx
    let nextFreeIdx = Option.fold (WriteLocateReqd dest) nextFreeIdx xx.LocateReqd
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = WriteOrdType dest nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WriteStopPx dest) nextFreeIdx xx.StopPx
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteComplianceID dest) nextFreeIdx xx.ComplianceID
    let nextFreeIdx = Option.fold (WriteIOIid dest) nextFreeIdx xx.IOIid
    let nextFreeIdx = Option.fold (WriteQuoteID dest) nextFreeIdx xx.QuoteID
    let nextFreeIdx = Option.fold (WriteTimeInForce dest) nextFreeIdx xx.TimeInForce
    let nextFreeIdx = Option.fold (WriteEffectiveTime dest) nextFreeIdx xx.EffectiveTime
    let nextFreeIdx = Option.fold (WriteExpireDate dest) nextFreeIdx xx.ExpireDate
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteGTBookingInst dest) nextFreeIdx xx.GTBookingInst
    let nextFreeIdx = Option.fold (WriteMaxShow dest) nextFreeIdx xx.MaxShow
    let nextFreeIdx = Option.fold (WritePegInstructions dest) nextFreeIdx xx.PegInstructions    // component option
    let nextFreeIdx = Option.fold (WriteDiscretionInstructions dest) nextFreeIdx xx.DiscretionInstructions    // component option
    let nextFreeIdx = Option.fold (WriteTargetStrategy dest) nextFreeIdx xx.TargetStrategy
    let nextFreeIdx = Option.fold (WriteTargetStrategyParameters dest) nextFreeIdx xx.TargetStrategyParameters
    let nextFreeIdx = Option.fold (WriteParticipationRate dest) nextFreeIdx xx.ParticipationRate
    let nextFreeIdx = Option.fold (WriteCancellationRights dest) nextFreeIdx xx.CancellationRights
    let nextFreeIdx = Option.fold (WriteMoneyLaunderingStatus dest) nextFreeIdx xx.MoneyLaunderingStatus
    let nextFreeIdx = Option.fold (WriteRegistID dest) nextFreeIdx xx.RegistID
    let nextFreeIdx = Option.fold (WriteDesignation dest) nextFreeIdx xx.Designation
    nextFreeIdx


// tag: u
let WriteCrossOrderCancelRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:CrossOrderCancelRequest) = 
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = WriteCrossID dest nextFreeIdx xx.CrossID
    let nextFreeIdx = WriteOrigCrossID dest nextFreeIdx xx.OrigCrossID
    let nextFreeIdx = WriteCrossType dest nextFreeIdx xx.CrossType
    let nextFreeIdx = WriteCrossPrioritization dest nextFreeIdx xx.CrossPrioritization
    let noSidesField =  // ####
        match xx.CrossOrderCancelRequest_NoSidesGrp with
        | OneOrTwo.One _ -> NoSides.OneSide
        | OneOrTwo.Two _ -> NoSides.BothSides
    let nextFreeIdx = WriteNoSides dest nextFreeIdx noSidesField
    let nextFreeIdx = xx.CrossOrderCancelRequest_NoSidesGrp |> OneOrTwo.fold (WriteCrossOrderCancelRequest_NoSidesGrp dest) nextFreeIdx  // group
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    nextFreeIdx


// tag: AB
let WriteNewOrderMultileg (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:NewOrderMultileg) = 
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteClOrdLinkID dest) nextFreeIdx xx.ClOrdLinkID
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteDayBookingInst dest) nextFreeIdx xx.DayBookingInst
    let nextFreeIdx = Option.fold (WriteBookingUnit dest) nextFreeIdx xx.BookingUnit
    let nextFreeIdx = Option.fold (WritePreallocMethod dest) nextFreeIdx xx.PreallocMethod
    let nextFreeIdx = Option.fold (WriteAllocID dest) nextFreeIdx xx.AllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NewOrderMultileg_NoAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAllocs dest innerNextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNewOrderMultileg_NoAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NewOrderMultileg_NoAllocsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteCashMargin dest) nextFreeIdx xx.CashMargin
    let nextFreeIdx = Option.fold (WriteClearingFeeIndicator dest) nextFreeIdx xx.ClearingFeeIndicator
    let nextFreeIdx = Option.fold (WriteHandlInst dest) nextFreeIdx xx.HandlInst
    let nextFreeIdx = Option.fold (WriteExecInst dest) nextFreeIdx xx.ExecInst
    let nextFreeIdx = Option.fold (WriteMinQty dest) nextFreeIdx xx.MinQty
    let nextFreeIdx = Option.fold (WriteMaxFloor dest) nextFreeIdx xx.MaxFloor
    let nextFreeIdx = Option.fold (WriteExDestination dest) nextFreeIdx xx.ExDestination
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradingSessionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTradingSessions dest innerNextFreeIdx (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradingSessionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradingSessionsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteProcessCode dest) nextFreeIdx xx.ProcessCode
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePrevClosePx dest) nextFreeIdx xx.PrevClosePx
    let numGrps = xx.NewOrderMultileg_NoLegsGrp.Length
    let nextFreeIdx = WriteNoLegs dest nextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NewOrderMultileg_NoLegsGrp |> List.fold (fun accFreeIdx gg -> WriteNewOrderMultileg_NoLegsGrp dest accFreeIdx gg) nextFreeIdx
    let nextFreeIdx = Option.fold (WriteLocateReqd dest) nextFreeIdx xx.LocateReqd
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = WriteOrderQtyData dest nextFreeIdx xx.OrderQtyData   // component
    let nextFreeIdx = WriteOrdType dest nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WriteStopPx dest) nextFreeIdx xx.StopPx
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteComplianceID dest) nextFreeIdx xx.ComplianceID
    let nextFreeIdx = Option.fold (WriteSolicitedFlag dest) nextFreeIdx xx.SolicitedFlag
    let nextFreeIdx = Option.fold (WriteIOIid dest) nextFreeIdx xx.IOIid
    let nextFreeIdx = Option.fold (WriteQuoteID dest) nextFreeIdx xx.QuoteID
    let nextFreeIdx = Option.fold (WriteTimeInForce dest) nextFreeIdx xx.TimeInForce
    let nextFreeIdx = Option.fold (WriteEffectiveTime dest) nextFreeIdx xx.EffectiveTime
    let nextFreeIdx = Option.fold (WriteExpireDate dest) nextFreeIdx xx.ExpireDate
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteGTBookingInst dest) nextFreeIdx xx.GTBookingInst
    let nextFreeIdx = Option.fold (WriteCommissionData dest) nextFreeIdx xx.CommissionData    // component option
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WriteOrderRestrictions dest) nextFreeIdx xx.OrderRestrictions
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteForexReq dest) nextFreeIdx xx.ForexReq
    let nextFreeIdx = Option.fold (WriteSettlCurrency dest) nextFreeIdx xx.SettlCurrency
    let nextFreeIdx = Option.fold (WriteBookingType dest) nextFreeIdx xx.BookingType
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WritePositionEffect dest) nextFreeIdx xx.PositionEffect
    let nextFreeIdx = Option.fold (WriteCoveredOrUncovered dest) nextFreeIdx xx.CoveredOrUncovered
    let nextFreeIdx = Option.fold (WriteMaxShow dest) nextFreeIdx xx.MaxShow
    let nextFreeIdx = Option.fold (WritePegInstructions dest) nextFreeIdx xx.PegInstructions    // component option
    let nextFreeIdx = Option.fold (WriteDiscretionInstructions dest) nextFreeIdx xx.DiscretionInstructions    // component option
    let nextFreeIdx = Option.fold (WriteTargetStrategy dest) nextFreeIdx xx.TargetStrategy
    let nextFreeIdx = Option.fold (WriteTargetStrategyParameters dest) nextFreeIdx xx.TargetStrategyParameters
    let nextFreeIdx = Option.fold (WriteParticipationRate dest) nextFreeIdx xx.ParticipationRate
    let nextFreeIdx = Option.fold (WriteCancellationRights dest) nextFreeIdx xx.CancellationRights
    let nextFreeIdx = Option.fold (WriteMoneyLaunderingStatus dest) nextFreeIdx xx.MoneyLaunderingStatus
    let nextFreeIdx = Option.fold (WriteRegistID dest) nextFreeIdx xx.RegistID
    let nextFreeIdx = Option.fold (WriteDesignation dest) nextFreeIdx xx.Designation
    let nextFreeIdx = Option.fold (WriteMultiLegRptTypeReq dest) nextFreeIdx xx.MultiLegRptTypeReq
    nextFreeIdx


// tag: AC
let WriteMultilegOrderCancelReplaceRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:MultilegOrderCancelReplaceRequest) = 
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = WriteOrigClOrdID dest nextFreeIdx xx.OrigClOrdID
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteClOrdLinkID dest) nextFreeIdx xx.ClOrdLinkID
    let nextFreeIdx = Option.fold (WriteOrigOrdModTime dest) nextFreeIdx xx.OrigOrdModTime
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteDayBookingInst dest) nextFreeIdx xx.DayBookingInst
    let nextFreeIdx = Option.fold (WriteBookingUnit dest) nextFreeIdx xx.BookingUnit
    let nextFreeIdx = Option.fold (WritePreallocMethod dest) nextFreeIdx xx.PreallocMethod
    let nextFreeIdx = Option.fold (WriteAllocID dest) nextFreeIdx xx.AllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:MultilegOrderCancelReplaceRequest_NoAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAllocs dest innerNextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteMultilegOrderCancelReplaceRequest_NoAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.MultilegOrderCancelReplaceRequest_NoAllocsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteCashMargin dest) nextFreeIdx xx.CashMargin
    let nextFreeIdx = Option.fold (WriteClearingFeeIndicator dest) nextFreeIdx xx.ClearingFeeIndicator
    let nextFreeIdx = Option.fold (WriteHandlInst dest) nextFreeIdx xx.HandlInst
    let nextFreeIdx = Option.fold (WriteExecInst dest) nextFreeIdx xx.ExecInst
    let nextFreeIdx = Option.fold (WriteMinQty dest) nextFreeIdx xx.MinQty
    let nextFreeIdx = Option.fold (WriteMaxFloor dest) nextFreeIdx xx.MaxFloor
    let nextFreeIdx = Option.fold (WriteExDestination dest) nextFreeIdx xx.ExDestination
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradingSessionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTradingSessions dest innerNextFreeIdx (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradingSessionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradingSessionsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteProcessCode dest) nextFreeIdx xx.ProcessCode
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePrevClosePx dest) nextFreeIdx xx.PrevClosePx
    let numGrps = xx.MultilegOrderCancelReplaceRequest_NoLegsGrp.Length
    let nextFreeIdx = WriteNoLegs dest nextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.MultilegOrderCancelReplaceRequest_NoLegsGrp |> List.fold (fun accFreeIdx gg -> WriteMultilegOrderCancelReplaceRequest_NoLegsGrp dest accFreeIdx gg) nextFreeIdx
    let nextFreeIdx = Option.fold (WriteLocateReqd dest) nextFreeIdx xx.LocateReqd
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = WriteOrderQtyData dest nextFreeIdx xx.OrderQtyData   // component
    let nextFreeIdx = WriteOrdType dest nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WriteStopPx dest) nextFreeIdx xx.StopPx
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteComplianceID dest) nextFreeIdx xx.ComplianceID
    let nextFreeIdx = Option.fold (WriteSolicitedFlag dest) nextFreeIdx xx.SolicitedFlag
    let nextFreeIdx = Option.fold (WriteIOIid dest) nextFreeIdx xx.IOIid
    let nextFreeIdx = Option.fold (WriteQuoteID dest) nextFreeIdx xx.QuoteID
    let nextFreeIdx = Option.fold (WriteTimeInForce dest) nextFreeIdx xx.TimeInForce
    let nextFreeIdx = Option.fold (WriteEffectiveTime dest) nextFreeIdx xx.EffectiveTime
    let nextFreeIdx = Option.fold (WriteExpireDate dest) nextFreeIdx xx.ExpireDate
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteGTBookingInst dest) nextFreeIdx xx.GTBookingInst
    let nextFreeIdx = Option.fold (WriteCommissionData dest) nextFreeIdx xx.CommissionData    // component option
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WriteOrderRestrictions dest) nextFreeIdx xx.OrderRestrictions
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteForexReq dest) nextFreeIdx xx.ForexReq
    let nextFreeIdx = Option.fold (WriteSettlCurrency dest) nextFreeIdx xx.SettlCurrency
    let nextFreeIdx = Option.fold (WriteBookingType dest) nextFreeIdx xx.BookingType
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WritePositionEffect dest) nextFreeIdx xx.PositionEffect
    let nextFreeIdx = Option.fold (WriteCoveredOrUncovered dest) nextFreeIdx xx.CoveredOrUncovered
    let nextFreeIdx = Option.fold (WriteMaxShow dest) nextFreeIdx xx.MaxShow
    let nextFreeIdx = Option.fold (WritePegInstructions dest) nextFreeIdx xx.PegInstructions    // component option
    let nextFreeIdx = Option.fold (WriteDiscretionInstructions dest) nextFreeIdx xx.DiscretionInstructions    // component option
    let nextFreeIdx = Option.fold (WriteTargetStrategy dest) nextFreeIdx xx.TargetStrategy
    let nextFreeIdx = Option.fold (WriteTargetStrategyParameters dest) nextFreeIdx xx.TargetStrategyParameters
    let nextFreeIdx = Option.fold (WriteParticipationRate dest) nextFreeIdx xx.ParticipationRate
    let nextFreeIdx = Option.fold (WriteCancellationRights dest) nextFreeIdx xx.CancellationRights
    let nextFreeIdx = Option.fold (WriteMoneyLaunderingStatus dest) nextFreeIdx xx.MoneyLaunderingStatus
    let nextFreeIdx = Option.fold (WriteRegistID dest) nextFreeIdx xx.RegistID
    let nextFreeIdx = Option.fold (WriteDesignation dest) nextFreeIdx xx.Designation
    let nextFreeIdx = Option.fold (WriteMultiLegRptTypeReq dest) nextFreeIdx xx.MultiLegRptTypeReq
    nextFreeIdx


// tag: k
let WriteBidRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:BidRequest) = 
    let nextFreeIdx = Option.fold (WriteBidID dest) nextFreeIdx xx.BidID
    let nextFreeIdx = WriteClientBidID dest nextFreeIdx xx.ClientBidID
    let nextFreeIdx = WriteBidRequestTransType dest nextFreeIdx xx.BidRequestTransType
    let nextFreeIdx = Option.fold (WriteListName dest) nextFreeIdx xx.ListName
    let nextFreeIdx = WriteTotNoRelatedSym dest nextFreeIdx xx.TotNoRelatedSym
    let nextFreeIdx = WriteBidType dest nextFreeIdx xx.BidType
    let nextFreeIdx = Option.fold (WriteNumTickets dest) nextFreeIdx xx.NumTickets
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteSideValue1 dest) nextFreeIdx xx.SideValue1
    let nextFreeIdx = Option.fold (WriteSideValue2 dest) nextFreeIdx xx.SideValue2
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoBidDescriptorsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoBidDescriptors dest innerNextFreeIdx (Fix44.Fields.NoBidDescriptors numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoBidDescriptorsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoBidDescriptorsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoBidComponentsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoBidComponents dest innerNextFreeIdx (Fix44.Fields.NoBidComponents numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoBidComponentsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoBidComponentsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLiquidityIndType dest) nextFreeIdx xx.LiquidityIndType
    let nextFreeIdx = Option.fold (WriteWtAverageLiquidity dest) nextFreeIdx xx.WtAverageLiquidity
    let nextFreeIdx = Option.fold (WriteExchangeForPhysical dest) nextFreeIdx xx.ExchangeForPhysical
    let nextFreeIdx = Option.fold (WriteOutMainCntryUIndex dest) nextFreeIdx xx.OutMainCntryUIndex
    let nextFreeIdx = Option.fold (WriteCrossPercent dest) nextFreeIdx xx.CrossPercent
    let nextFreeIdx = Option.fold (WriteProgRptReqs dest) nextFreeIdx xx.ProgRptReqs
    let nextFreeIdx = Option.fold (WriteProgPeriodInterval dest) nextFreeIdx xx.ProgPeriodInterval
    let nextFreeIdx = Option.fold (WriteIncTaxInd dest) nextFreeIdx xx.IncTaxInd
    let nextFreeIdx = Option.fold (WriteForexReq dest) nextFreeIdx xx.ForexReq
    let nextFreeIdx = Option.fold (WriteNumBidders dest) nextFreeIdx xx.NumBidders
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = WriteBidTradeType dest nextFreeIdx xx.BidTradeType
    let nextFreeIdx = WriteBasisPxType dest nextFreeIdx xx.BasisPxType
    let nextFreeIdx = Option.fold (WriteStrikeTime dest) nextFreeIdx xx.StrikeTime
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: l
let WriteBidResponse (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:BidResponse) = 
    let nextFreeIdx = Option.fold (WriteBidID dest) nextFreeIdx xx.BidID
    let nextFreeIdx = Option.fold (WriteClientBidID dest) nextFreeIdx xx.ClientBidID
    let numGrps = xx.BidResponse_NoBidComponentsGrp.Length
    let nextFreeIdx = WriteNoBidComponents dest nextFreeIdx (Fix44.Fields.NoBidComponents numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.BidResponse_NoBidComponentsGrp |> List.fold (fun accFreeIdx gg -> WriteBidResponse_NoBidComponentsGrp dest accFreeIdx gg) nextFreeIdx
    nextFreeIdx


// tag: E
let WriteNewOrderList (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:NewOrderList) = 
    let nextFreeIdx = WriteListID dest nextFreeIdx xx.ListID
    let nextFreeIdx = Option.fold (WriteBidID dest) nextFreeIdx xx.BidID
    let nextFreeIdx = Option.fold (WriteClientBidID dest) nextFreeIdx xx.ClientBidID
    let nextFreeIdx = Option.fold (WriteProgRptReqs dest) nextFreeIdx xx.ProgRptReqs
    let nextFreeIdx = WriteBidType dest nextFreeIdx xx.BidType
    let nextFreeIdx = Option.fold (WriteProgPeriodInterval dest) nextFreeIdx xx.ProgPeriodInterval
    let nextFreeIdx = Option.fold (WriteCancellationRights dest) nextFreeIdx xx.CancellationRights
    let nextFreeIdx = Option.fold (WriteMoneyLaunderingStatus dest) nextFreeIdx xx.MoneyLaunderingStatus
    let nextFreeIdx = Option.fold (WriteRegistID dest) nextFreeIdx xx.RegistID
    let nextFreeIdx = Option.fold (WriteListExecInstType dest) nextFreeIdx xx.ListExecInstType
    let nextFreeIdx = Option.fold (WriteListExecInst dest) nextFreeIdx xx.ListExecInst
    let nextFreeIdx = Option.fold (WriteEncodedListExecInst dest) nextFreeIdx xx.EncodedListExecInst
    let nextFreeIdx = Option.fold (WriteAllowableOneSidednessPct dest) nextFreeIdx xx.AllowableOneSidednessPct
    let nextFreeIdx = Option.fold (WriteAllowableOneSidednessValue dest) nextFreeIdx xx.AllowableOneSidednessValue
    let nextFreeIdx = Option.fold (WriteAllowableOneSidednessCurr dest) nextFreeIdx xx.AllowableOneSidednessCurr
    let nextFreeIdx = WriteTotNoOrders dest nextFreeIdx xx.TotNoOrders
    let nextFreeIdx = Option.fold (WriteLastFragment dest) nextFreeIdx xx.LastFragment
    let numGrps = xx.NewOrderList_NoOrdersGrp.Length
    let nextFreeIdx = WriteNoOrders dest nextFreeIdx (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NewOrderList_NoOrdersGrp |> List.fold (fun accFreeIdx gg -> WriteNewOrderList_NoOrdersGrp dest accFreeIdx gg) nextFreeIdx
    nextFreeIdx


// tag: m
let WriteListStrikePrice (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:ListStrikePrice) = 
    let nextFreeIdx = WriteListID dest nextFreeIdx xx.ListID
    let nextFreeIdx = WriteTotNoStrikes dest nextFreeIdx xx.TotNoStrikes
    let nextFreeIdx = Option.fold (WriteLastFragment dest) nextFreeIdx xx.LastFragment
    let numGrps = xx.NoStrikesGrp.Length
    let nextFreeIdx = WriteNoStrikes dest nextFreeIdx (Fix44.Fields.NoStrikes numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NoStrikesGrp |> List.fold (fun accFreeIdx gg -> WriteNoStrikesGrp dest accFreeIdx gg) nextFreeIdx
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:ListStrikePrice_NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteListStrikePrice_NoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.ListStrikePrice_NoUnderlyingsGrp  // end Option.fold
    nextFreeIdx


// tag: N
let WriteListStatus (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:ListStatus) = 
    let nextFreeIdx = WriteListID dest nextFreeIdx xx.ListID
    let nextFreeIdx = WriteListStatusType dest nextFreeIdx xx.ListStatusType
    let nextFreeIdx = WriteNoRpts dest nextFreeIdx xx.NoRpts
    let nextFreeIdx = WriteListOrderStatus dest nextFreeIdx xx.ListOrderStatus
    let nextFreeIdx = WriteRptSeq dest nextFreeIdx xx.RptSeq
    let nextFreeIdx = Option.fold (WriteListStatusText dest) nextFreeIdx xx.ListStatusText
    let nextFreeIdx = Option.fold (WriteEncodedListStatusText dest) nextFreeIdx xx.EncodedListStatusText
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = WriteTotNoOrders dest nextFreeIdx xx.TotNoOrders
    let nextFreeIdx = Option.fold (WriteLastFragment dest) nextFreeIdx xx.LastFragment
    let numGrps = xx.ListStatus_NoOrdersGrp.Length
    let nextFreeIdx = WriteNoOrders dest nextFreeIdx (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.ListStatus_NoOrdersGrp |> List.fold (fun accFreeIdx gg -> WriteListStatus_NoOrdersGrp dest accFreeIdx gg) nextFreeIdx
    nextFreeIdx


// tag: L
let WriteListExecute (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:ListExecute) = 
    let nextFreeIdx = WriteListID dest nextFreeIdx xx.ListID
    let nextFreeIdx = Option.fold (WriteClientBidID dest) nextFreeIdx xx.ClientBidID
    let nextFreeIdx = Option.fold (WriteBidID dest) nextFreeIdx xx.BidID
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: K
let WriteListCancelRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:ListCancelRequest) = 
    let nextFreeIdx = WriteListID dest nextFreeIdx xx.ListID
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: M
let WriteListStatusRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:ListStatusRequest) = 
    let nextFreeIdx = WriteListID dest nextFreeIdx xx.ListID
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: J
let WriteAllocationInstruction (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:AllocationInstruction) = 
    let nextFreeIdx = WriteAllocID dest nextFreeIdx xx.AllocID
    let nextFreeIdx = WriteAllocTransType dest nextFreeIdx xx.AllocTransType
    let nextFreeIdx = WriteAllocType dest nextFreeIdx xx.AllocType
    let nextFreeIdx = Option.fold (WriteSecondaryAllocID dest) nextFreeIdx xx.SecondaryAllocID
    let nextFreeIdx = Option.fold (WriteRefAllocID dest) nextFreeIdx xx.RefAllocID
    let nextFreeIdx = Option.fold (WriteAllocCancReplaceReason dest) nextFreeIdx xx.AllocCancReplaceReason
    let nextFreeIdx = Option.fold (WriteAllocIntermedReqType dest) nextFreeIdx xx.AllocIntermedReqType
    let nextFreeIdx = Option.fold (WriteAllocLinkID dest) nextFreeIdx xx.AllocLinkID
    let nextFreeIdx = Option.fold (WriteAllocLinkType dest) nextFreeIdx xx.AllocLinkType
    let nextFreeIdx = Option.fold (WriteBookingRefID dest) nextFreeIdx xx.BookingRefID
    let nextFreeIdx = WriteAllocNoOrdersType dest nextFreeIdx xx.AllocNoOrdersType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoOrdersGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoOrders dest innerNextFreeIdx (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoOrdersGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoOrdersGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:AllocationInstruction_NoExecsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoExecs dest innerNextFreeIdx (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteAllocationInstruction_NoExecsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.AllocationInstruction_NoExecsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePreviouslyReported dest) nextFreeIdx xx.PreviouslyReported
    let nextFreeIdx = Option.fold (WriteReversalIndicator dest) nextFreeIdx xx.ReversalIndicator
    let nextFreeIdx = Option.fold (WriteMatchType dest) nextFreeIdx xx.MatchType
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteInstrumentExtension dest) nextFreeIdx xx.InstrumentExtension    // component option
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = WriteQuantity dest nextFreeIdx xx.Quantity
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = Option.fold (WriteLastMkt dest) nextFreeIdx xx.LastMkt
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = WriteAvgPx dest nextFreeIdx xx.AvgPx
    let nextFreeIdx = Option.fold (WriteAvgParPx dest) nextFreeIdx xx.AvgParPx
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteAvgPxPrecision dest) nextFreeIdx xx.AvgPxPrecision
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = WriteTradeDate dest nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteBookingType dest) nextFreeIdx xx.BookingType
    let nextFreeIdx = Option.fold (WriteGrossTradeAmt dest) nextFreeIdx xx.GrossTradeAmt
    let nextFreeIdx = Option.fold (WriteConcession dest) nextFreeIdx xx.Concession
    let nextFreeIdx = Option.fold (WriteTotalTakedown dest) nextFreeIdx xx.TotalTakedown
    let nextFreeIdx = Option.fold (WriteNetMoney dest) nextFreeIdx xx.NetMoney
    let nextFreeIdx = Option.fold (WritePositionEffect dest) nextFreeIdx xx.PositionEffect
    let nextFreeIdx = Option.fold (WriteAutoAcceptIndicator dest) nextFreeIdx xx.AutoAcceptIndicator
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteNumDaysInterest dest) nextFreeIdx xx.NumDaysInterest
    let nextFreeIdx = Option.fold (WriteAccruedInterestRate dest) nextFreeIdx xx.AccruedInterestRate
    let nextFreeIdx = Option.fold (WriteAccruedInterestAmt dest) nextFreeIdx xx.AccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteTotalAccruedInterestAmt dest) nextFreeIdx xx.TotalAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteInterestAtMaturity dest) nextFreeIdx xx.InterestAtMaturity
    let nextFreeIdx = Option.fold (WriteEndAccruedInterestAmt dest) nextFreeIdx xx.EndAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteStartCash dest) nextFreeIdx xx.StartCash
    let nextFreeIdx = Option.fold (WriteEndCash dest) nextFreeIdx xx.EndCash
    let nextFreeIdx = Option.fold (WriteLegalConfirm dest) nextFreeIdx xx.LegalConfirm
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    let nextFreeIdx = Option.fold (WriteTotNoAllocs dest) nextFreeIdx xx.TotNoAllocs
    let nextFreeIdx = Option.fold (WriteLastFragment dest) nextFreeIdx xx.LastFragment
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:AllocationInstruction_NoAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAllocs dest innerNextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteAllocationInstruction_NoAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.AllocationInstruction_NoAllocsGrp  // end Option.fold
    nextFreeIdx


// tag: P
let WriteAllocationInstructionAck (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:AllocationInstructionAck) = 
    let nextFreeIdx = WriteAllocID dest nextFreeIdx xx.AllocID
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteSecondaryAllocID dest) nextFreeIdx xx.SecondaryAllocID
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = WriteAllocStatus dest nextFreeIdx xx.AllocStatus
    let nextFreeIdx = Option.fold (WriteAllocRejCode dest) nextFreeIdx xx.AllocRejCode
    let nextFreeIdx = Option.fold (WriteAllocType dest) nextFreeIdx xx.AllocType
    let nextFreeIdx = Option.fold (WriteAllocIntermedReqType dest) nextFreeIdx xx.AllocIntermedReqType
    let nextFreeIdx = Option.fold (WriteMatchStatus dest) nextFreeIdx xx.MatchStatus
    let nextFreeIdx = Option.fold (WriteProduct dest) nextFreeIdx xx.Product
    let nextFreeIdx = Option.fold (WriteSecurityType dest) nextFreeIdx xx.SecurityType
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:AllocationInstructionAck_NoAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAllocs dest innerNextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteAllocationInstructionAck_NoAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.AllocationInstructionAck_NoAllocsGrp  // end Option.fold
    nextFreeIdx


// tag: AS
let WriteAllocationReport (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:AllocationReport) = 
    let nextFreeIdx = WriteAllocReportID dest nextFreeIdx xx.AllocReportID
    let nextFreeIdx = Option.fold (WriteAllocID dest) nextFreeIdx xx.AllocID
    let nextFreeIdx = WriteAllocTransType dest nextFreeIdx xx.AllocTransType
    let nextFreeIdx = Option.fold (WriteAllocReportRefID dest) nextFreeIdx xx.AllocReportRefID
    let nextFreeIdx = Option.fold (WriteAllocCancReplaceReason dest) nextFreeIdx xx.AllocCancReplaceReason
    let nextFreeIdx = Option.fold (WriteSecondaryAllocID dest) nextFreeIdx xx.SecondaryAllocID
    let nextFreeIdx = WriteAllocReportType dest nextFreeIdx xx.AllocReportType
    let nextFreeIdx = WriteAllocStatus dest nextFreeIdx xx.AllocStatus
    let nextFreeIdx = Option.fold (WriteAllocRejCode dest) nextFreeIdx xx.AllocRejCode
    let nextFreeIdx = Option.fold (WriteRefAllocID dest) nextFreeIdx xx.RefAllocID
    let nextFreeIdx = Option.fold (WriteAllocIntermedReqType dest) nextFreeIdx xx.AllocIntermedReqType
    let nextFreeIdx = Option.fold (WriteAllocLinkID dest) nextFreeIdx xx.AllocLinkID
    let nextFreeIdx = Option.fold (WriteAllocLinkType dest) nextFreeIdx xx.AllocLinkType
    let nextFreeIdx = Option.fold (WriteBookingRefID dest) nextFreeIdx xx.BookingRefID
    let nextFreeIdx = WriteAllocNoOrdersType dest nextFreeIdx xx.AllocNoOrdersType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoOrdersGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoOrders dest innerNextFreeIdx (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoOrdersGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoOrdersGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:AllocationReport_NoExecsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoExecs dest innerNextFreeIdx (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteAllocationReport_NoExecsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.AllocationReport_NoExecsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePreviouslyReported dest) nextFreeIdx xx.PreviouslyReported
    let nextFreeIdx = Option.fold (WriteReversalIndicator dest) nextFreeIdx xx.ReversalIndicator
    let nextFreeIdx = Option.fold (WriteMatchType dest) nextFreeIdx xx.MatchType
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteInstrumentExtension dest) nextFreeIdx xx.InstrumentExtension    // component option
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = WriteQuantity dest nextFreeIdx xx.Quantity
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = Option.fold (WriteLastMkt dest) nextFreeIdx xx.LastMkt
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = WriteAvgPx dest nextFreeIdx xx.AvgPx
    let nextFreeIdx = Option.fold (WriteAvgParPx dest) nextFreeIdx xx.AvgParPx
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteAvgPxPrecision dest) nextFreeIdx xx.AvgPxPrecision
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = WriteTradeDate dest nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteBookingType dest) nextFreeIdx xx.BookingType
    let nextFreeIdx = Option.fold (WriteGrossTradeAmt dest) nextFreeIdx xx.GrossTradeAmt
    let nextFreeIdx = Option.fold (WriteConcession dest) nextFreeIdx xx.Concession
    let nextFreeIdx = Option.fold (WriteTotalTakedown dest) nextFreeIdx xx.TotalTakedown
    let nextFreeIdx = Option.fold (WriteNetMoney dest) nextFreeIdx xx.NetMoney
    let nextFreeIdx = Option.fold (WritePositionEffect dest) nextFreeIdx xx.PositionEffect
    let nextFreeIdx = Option.fold (WriteAutoAcceptIndicator dest) nextFreeIdx xx.AutoAcceptIndicator
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteNumDaysInterest dest) nextFreeIdx xx.NumDaysInterest
    let nextFreeIdx = Option.fold (WriteAccruedInterestRate dest) nextFreeIdx xx.AccruedInterestRate
    let nextFreeIdx = Option.fold (WriteAccruedInterestAmt dest) nextFreeIdx xx.AccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteTotalAccruedInterestAmt dest) nextFreeIdx xx.TotalAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteInterestAtMaturity dest) nextFreeIdx xx.InterestAtMaturity
    let nextFreeIdx = Option.fold (WriteEndAccruedInterestAmt dest) nextFreeIdx xx.EndAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteStartCash dest) nextFreeIdx xx.StartCash
    let nextFreeIdx = Option.fold (WriteEndCash dest) nextFreeIdx xx.EndCash
    let nextFreeIdx = Option.fold (WriteLegalConfirm dest) nextFreeIdx xx.LegalConfirm
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    let nextFreeIdx = Option.fold (WriteTotNoAllocs dest) nextFreeIdx xx.TotNoAllocs
    let nextFreeIdx = Option.fold (WriteLastFragment dest) nextFreeIdx xx.LastFragment
    let numGrps = xx.AllocationReport_NoAllocsGrp.Length
    let nextFreeIdx = WriteNoAllocs dest nextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.AllocationReport_NoAllocsGrp |> List.fold (fun accFreeIdx gg -> WriteAllocationReport_NoAllocsGrp dest accFreeIdx gg) nextFreeIdx
    nextFreeIdx


// tag: AT
let WriteAllocationReportAck (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:AllocationReportAck) = 
    let nextFreeIdx = WriteAllocReportID dest nextFreeIdx xx.AllocReportID
    let nextFreeIdx = WriteAllocID dest nextFreeIdx xx.AllocID
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteSecondaryAllocID dest) nextFreeIdx xx.SecondaryAllocID
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = WriteAllocStatus dest nextFreeIdx xx.AllocStatus
    let nextFreeIdx = Option.fold (WriteAllocRejCode dest) nextFreeIdx xx.AllocRejCode
    let nextFreeIdx = Option.fold (WriteAllocReportType dest) nextFreeIdx xx.AllocReportType
    let nextFreeIdx = Option.fold (WriteAllocIntermedReqType dest) nextFreeIdx xx.AllocIntermedReqType
    let nextFreeIdx = Option.fold (WriteMatchStatus dest) nextFreeIdx xx.MatchStatus
    let nextFreeIdx = Option.fold (WriteProduct dest) nextFreeIdx xx.Product
    let nextFreeIdx = Option.fold (WriteSecurityType dest) nextFreeIdx xx.SecurityType
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:AllocationReportAck_NoAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAllocs dest innerNextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteAllocationReportAck_NoAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.AllocationReportAck_NoAllocsGrp  // end Option.fold
    nextFreeIdx


// tag: AK
let WriteConfirmation (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:Confirmation) = 
    let nextFreeIdx = WriteConfirmID dest nextFreeIdx xx.ConfirmID
    let nextFreeIdx = Option.fold (WriteConfirmRefID dest) nextFreeIdx xx.ConfirmRefID
    let nextFreeIdx = Option.fold (WriteConfirmReqID dest) nextFreeIdx xx.ConfirmReqID
    let nextFreeIdx = WriteConfirmTransType dest nextFreeIdx xx.ConfirmTransType
    let nextFreeIdx = WriteConfirmType dest nextFreeIdx xx.ConfirmType
    let nextFreeIdx = Option.fold (WriteCopyMsgIndicator dest) nextFreeIdx xx.CopyMsgIndicator
    let nextFreeIdx = Option.fold (WriteLegalConfirm dest) nextFreeIdx xx.LegalConfirm
    let nextFreeIdx = WriteConfirmStatus dest nextFreeIdx xx.ConfirmStatus
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoOrdersGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoOrders dest innerNextFreeIdx (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoOrdersGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoOrdersGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteAllocID dest) nextFreeIdx xx.AllocID
    let nextFreeIdx = Option.fold (WriteSecondaryAllocID dest) nextFreeIdx xx.SecondaryAllocID
    let nextFreeIdx = Option.fold (WriteIndividualAllocID dest) nextFreeIdx xx.IndividualAllocID
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = WriteTradeDate dest nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteTrdRegTimestamps dest) nextFreeIdx xx.TrdRegTimestamps    // component option
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteInstrumentExtension dest) nextFreeIdx xx.InstrumentExtension    // component option
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    let numGrps = xx.NoUnderlyingsGrp.Length
    let nextFreeIdx = WriteNoUnderlyings dest nextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NoUnderlyingsGrp |> List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) nextFreeIdx
    let numGrps = xx.NoLegsGrp.Length
    let nextFreeIdx = WriteNoLegs dest nextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NoLegsGrp |> List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) nextFreeIdx
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    let nextFreeIdx = WriteAllocQty dest nextFreeIdx xx.AllocQty
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteLastMkt dest) nextFreeIdx xx.LastMkt
    let numGrps = xx.NoCapacitiesGrp.Length
    let nextFreeIdx = WriteNoCapacities dest nextFreeIdx (Fix44.Fields.NoCapacities numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NoCapacitiesGrp |> List.fold (fun accFreeIdx gg -> WriteNoCapacitiesGrp dest accFreeIdx gg) nextFreeIdx
    let nextFreeIdx = WriteAllocAccount dest nextFreeIdx xx.AllocAccount
    let nextFreeIdx = Option.fold (WriteAllocAcctIDSource dest) nextFreeIdx xx.AllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteAllocAccountType dest) nextFreeIdx xx.AllocAccountType
    let nextFreeIdx = WriteAvgPx dest nextFreeIdx xx.AvgPx
    let nextFreeIdx = Option.fold (WriteAvgPxPrecision dest) nextFreeIdx xx.AvgPxPrecision
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WriteAvgParPx dest) nextFreeIdx xx.AvgParPx
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteReportedPx dest) nextFreeIdx xx.ReportedPx
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteProcessCode dest) nextFreeIdx xx.ProcessCode
    let nextFreeIdx = WriteGrossTradeAmt dest nextFreeIdx xx.GrossTradeAmt
    let nextFreeIdx = Option.fold (WriteNumDaysInterest dest) nextFreeIdx xx.NumDaysInterest
    let nextFreeIdx = Option.fold (WriteExDate dest) nextFreeIdx xx.ExDate
    let nextFreeIdx = Option.fold (WriteAccruedInterestRate dest) nextFreeIdx xx.AccruedInterestRate
    let nextFreeIdx = Option.fold (WriteAccruedInterestAmt dest) nextFreeIdx xx.AccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteInterestAtMaturity dest) nextFreeIdx xx.InterestAtMaturity
    let nextFreeIdx = Option.fold (WriteEndAccruedInterestAmt dest) nextFreeIdx xx.EndAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteStartCash dest) nextFreeIdx xx.StartCash
    let nextFreeIdx = Option.fold (WriteEndCash dest) nextFreeIdx xx.EndCash
    let nextFreeIdx = Option.fold (WriteConcession dest) nextFreeIdx xx.Concession
    let nextFreeIdx = Option.fold (WriteTotalTakedown dest) nextFreeIdx xx.TotalTakedown
    let nextFreeIdx = WriteNetMoney dest nextFreeIdx xx.NetMoney
    let nextFreeIdx = Option.fold (WriteMaturityNetMoney dest) nextFreeIdx xx.MaturityNetMoney
    let nextFreeIdx = Option.fold (WriteSettlCurrAmt dest) nextFreeIdx xx.SettlCurrAmt
    let nextFreeIdx = Option.fold (WriteSettlCurrency dest) nextFreeIdx xx.SettlCurrency
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRate dest) nextFreeIdx xx.SettlCurrFxRate
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRateCalc dest) nextFreeIdx xx.SettlCurrFxRateCalc
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteSettlInstructionsData dest) nextFreeIdx xx.SettlInstructionsData    // component option
    let nextFreeIdx = Option.fold (WriteCommissionData dest) nextFreeIdx xx.CommissionData    // component option
    let nextFreeIdx = Option.fold (WriteSharedCommission dest) nextFreeIdx xx.SharedCommission
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoMiscFeesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoMiscFees dest innerNextFreeIdx (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoMiscFeesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoMiscFeesGrp  // end Option.fold
    nextFreeIdx


// tag: AU
let WriteConfirmationAck (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:ConfirmationAck) = 
    let nextFreeIdx = WriteConfirmID dest nextFreeIdx xx.ConfirmID
    let nextFreeIdx = WriteTradeDate dest nextFreeIdx xx.TradeDate
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = WriteAffirmStatus dest nextFreeIdx xx.AffirmStatus
    let nextFreeIdx = Option.fold (WriteConfirmRejReason dest) nextFreeIdx xx.ConfirmRejReason
    let nextFreeIdx = Option.fold (WriteMatchStatus dest) nextFreeIdx xx.MatchStatus
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: BH
let WriteConfirmationRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:ConfirmationRequest) = 
    let nextFreeIdx = WriteConfirmReqID dest nextFreeIdx xx.ConfirmReqID
    let nextFreeIdx = WriteConfirmType dest nextFreeIdx xx.ConfirmType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoOrdersGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoOrders dest innerNextFreeIdx (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoOrdersGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoOrdersGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteAllocID dest) nextFreeIdx xx.AllocID
    let nextFreeIdx = Option.fold (WriteSecondaryAllocID dest) nextFreeIdx xx.SecondaryAllocID
    let nextFreeIdx = Option.fold (WriteIndividualAllocID dest) nextFreeIdx xx.IndividualAllocID
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteAllocAccount dest) nextFreeIdx xx.AllocAccount
    let nextFreeIdx = Option.fold (WriteAllocAcctIDSource dest) nextFreeIdx xx.AllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteAllocAccountType dest) nextFreeIdx xx.AllocAccountType
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: T
let WriteSettlementInstructions (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:SettlementInstructions) = 
    let nextFreeIdx = WriteSettlInstMsgID dest nextFreeIdx xx.SettlInstMsgID
    let nextFreeIdx = Option.fold (WriteSettlInstReqID dest) nextFreeIdx xx.SettlInstReqID
    let nextFreeIdx = WriteSettlInstMode dest nextFreeIdx xx.SettlInstMode
    let nextFreeIdx = Option.fold (WriteSettlInstReqRejCode dest) nextFreeIdx xx.SettlInstReqRejCode
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteSettlInstSource dest) nextFreeIdx xx.SettlInstSource
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoSettlInstGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoSettlInst dest innerNextFreeIdx (Fix44.Fields.NoSettlInst numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoSettlInstGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoSettlInstGrp  // end Option.fold
    nextFreeIdx


// tag: AV
let WriteSettlementInstructionRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:SettlementInstructionRequest) = 
    let nextFreeIdx = WriteSettlInstReqID dest nextFreeIdx xx.SettlInstReqID
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAllocAccount dest) nextFreeIdx xx.AllocAccount
    let nextFreeIdx = Option.fold (WriteAllocAcctIDSource dest) nextFreeIdx xx.AllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteProduct dest) nextFreeIdx xx.Product
    let nextFreeIdx = Option.fold (WriteSecurityType dest) nextFreeIdx xx.SecurityType
    let nextFreeIdx = Option.fold (WriteCFICode dest) nextFreeIdx xx.CFICode
    let nextFreeIdx = Option.fold (WriteEffectiveTime dest) nextFreeIdx xx.EffectiveTime
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteLastUpdateTime dest) nextFreeIdx xx.LastUpdateTime
    let nextFreeIdx = Option.fold (WriteStandInstDbType dest) nextFreeIdx xx.StandInstDbType
    let nextFreeIdx = Option.fold (WriteStandInstDbName dest) nextFreeIdx xx.StandInstDbName
    let nextFreeIdx = Option.fold (WriteStandInstDbID dest) nextFreeIdx xx.StandInstDbID
    nextFreeIdx


// tag: AD
let WriteTradeCaptureReportRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:TradeCaptureReportRequest) = 
    let nextFreeIdx = WriteTradeRequestID dest nextFreeIdx xx.TradeRequestID
    let nextFreeIdx = WriteTradeRequestType dest nextFreeIdx xx.TradeRequestType
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    let nextFreeIdx = Option.fold (WriteTradeReportID dest) nextFreeIdx xx.TradeReportID
    let nextFreeIdx = Option.fold (WriteSecondaryTradeReportID dest) nextFreeIdx xx.SecondaryTradeReportID
    let nextFreeIdx = Option.fold (WriteExecID dest) nextFreeIdx xx.ExecID
    let nextFreeIdx = Option.fold (WriteExecType dest) nextFreeIdx xx.ExecType
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteMatchStatus dest) nextFreeIdx xx.MatchStatus
    let nextFreeIdx = Option.fold (WriteTrdType dest) nextFreeIdx xx.TrdType
    let nextFreeIdx = Option.fold (WriteTrdSubType dest) nextFreeIdx xx.TrdSubType
    let nextFreeIdx = Option.fold (WriteTransferReason dest) nextFreeIdx xx.TransferReason
    let nextFreeIdx = Option.fold (WriteSecondaryTrdType dest) nextFreeIdx xx.SecondaryTrdType
    let nextFreeIdx = Option.fold (WriteTradeLinkID dest) nextFreeIdx xx.TradeLinkID
    let nextFreeIdx = Option.fold (WriteTrdMatchID dest) nextFreeIdx xx.TrdMatchID
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteInstrumentExtension dest) nextFreeIdx xx.InstrumentExtension    // component option
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoDatesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoDates dest innerNextFreeIdx (Fix44.Fields.NoDates numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoDatesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoDatesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteClearingBusinessDate dest) nextFreeIdx xx.ClearingBusinessDate
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteTimeBracket dest) nextFreeIdx xx.TimeBracket
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteMultiLegReportingType dest) nextFreeIdx xx.MultiLegReportingType
    let nextFreeIdx = Option.fold (WriteTradeInputSource dest) nextFreeIdx xx.TradeInputSource
    let nextFreeIdx = Option.fold (WriteTradeInputDevice dest) nextFreeIdx xx.TradeInputDevice
    let nextFreeIdx = Option.fold (WriteResponseTransportType dest) nextFreeIdx xx.ResponseTransportType
    let nextFreeIdx = Option.fold (WriteResponseDestination dest) nextFreeIdx xx.ResponseDestination
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AQ
let WriteTradeCaptureReportRequestAck (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:TradeCaptureReportRequestAck) = 
    let nextFreeIdx = WriteTradeRequestID dest nextFreeIdx xx.TradeRequestID
    let nextFreeIdx = WriteTradeRequestType dest nextFreeIdx xx.TradeRequestType
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    let nextFreeIdx = Option.fold (WriteTotNumTradeReports dest) nextFreeIdx xx.TotNumTradeReports
    let nextFreeIdx = WriteTradeRequestResult dest nextFreeIdx xx.TradeRequestResult
    let nextFreeIdx = WriteTradeRequestStatus dest nextFreeIdx xx.TradeRequestStatus
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteMultiLegReportingType dest) nextFreeIdx xx.MultiLegReportingType
    let nextFreeIdx = Option.fold (WriteResponseTransportType dest) nextFreeIdx xx.ResponseTransportType
    let nextFreeIdx = Option.fold (WriteResponseDestination dest) nextFreeIdx xx.ResponseDestination
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AE
let WriteTradeCaptureReport (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:TradeCaptureReport) = 
    let nextFreeIdx = WriteTradeReportID dest nextFreeIdx xx.TradeReportID
    let nextFreeIdx = Option.fold (WriteTradeReportTransType dest) nextFreeIdx xx.TradeReportTransType
    let nextFreeIdx = Option.fold (WriteTradeReportType dest) nextFreeIdx xx.TradeReportType
    let nextFreeIdx = Option.fold (WriteTradeRequestID dest) nextFreeIdx xx.TradeRequestID
    let nextFreeIdx = Option.fold (WriteTrdType dest) nextFreeIdx xx.TrdType
    let nextFreeIdx = Option.fold (WriteTrdSubType dest) nextFreeIdx xx.TrdSubType
    let nextFreeIdx = Option.fold (WriteSecondaryTrdType dest) nextFreeIdx xx.SecondaryTrdType
    let nextFreeIdx = Option.fold (WriteTransferReason dest) nextFreeIdx xx.TransferReason
    let nextFreeIdx = Option.fold (WriteExecType dest) nextFreeIdx xx.ExecType
    let nextFreeIdx = Option.fold (WriteTotNumTradeReports dest) nextFreeIdx xx.TotNumTradeReports
    let nextFreeIdx = Option.fold (WriteLastRptRequested dest) nextFreeIdx xx.LastRptRequested
    let nextFreeIdx = Option.fold (WriteUnsolicitedIndicator dest) nextFreeIdx xx.UnsolicitedIndicator
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    let nextFreeIdx = Option.fold (WriteTradeReportRefID dest) nextFreeIdx xx.TradeReportRefID
    let nextFreeIdx = Option.fold (WriteSecondaryTradeReportRefID dest) nextFreeIdx xx.SecondaryTradeReportRefID
    let nextFreeIdx = Option.fold (WriteSecondaryTradeReportID dest) nextFreeIdx xx.SecondaryTradeReportID
    let nextFreeIdx = Option.fold (WriteTradeLinkID dest) nextFreeIdx xx.TradeLinkID
    let nextFreeIdx = Option.fold (WriteTrdMatchID dest) nextFreeIdx xx.TrdMatchID
    let nextFreeIdx = Option.fold (WriteExecID dest) nextFreeIdx xx.ExecID
    let nextFreeIdx = Option.fold (WriteOrdStatus dest) nextFreeIdx xx.OrdStatus
    let nextFreeIdx = Option.fold (WriteSecondaryExecID dest) nextFreeIdx xx.SecondaryExecID
    let nextFreeIdx = Option.fold (WriteExecRestatementReason dest) nextFreeIdx xx.ExecRestatementReason
    let nextFreeIdx = WritePreviouslyReported dest nextFreeIdx xx.PreviouslyReported
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    let nextFreeIdx = Option.fold (WriteOrderQtyData dest) nextFreeIdx xx.OrderQtyData    // component option
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = Option.fold (WriteYieldData dest) nextFreeIdx xx.YieldData    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteUnderlyingTradingSessionID dest) nextFreeIdx xx.UnderlyingTradingSessionID
    let nextFreeIdx = Option.fold (WriteUnderlyingTradingSessionSubID dest) nextFreeIdx xx.UnderlyingTradingSessionSubID
    let nextFreeIdx = WriteLastQty dest nextFreeIdx xx.LastQty
    let nextFreeIdx = WriteLastPx dest nextFreeIdx xx.LastPx
    let nextFreeIdx = Option.fold (WriteLastParPx dest) nextFreeIdx xx.LastParPx
    let nextFreeIdx = Option.fold (WriteLastSpotRate dest) nextFreeIdx xx.LastSpotRate
    let nextFreeIdx = Option.fold (WriteLastForwardPoints dest) nextFreeIdx xx.LastForwardPoints
    let nextFreeIdx = Option.fold (WriteLastMkt dest) nextFreeIdx xx.LastMkt
    let nextFreeIdx = WriteTradeDate dest nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteClearingBusinessDate dest) nextFreeIdx xx.ClearingBusinessDate
    let nextFreeIdx = Option.fold (WriteAvgPx dest) nextFreeIdx xx.AvgPx
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteAvgPxIndicator dest) nextFreeIdx xx.AvgPxIndicator
    let nextFreeIdx = Option.fold (WritePositionAmountData dest) nextFreeIdx xx.PositionAmountData    // component option
    let nextFreeIdx = Option.fold (WriteMultiLegReportingType dest) nextFreeIdx xx.MultiLegReportingType
    let nextFreeIdx = Option.fold (WriteTradeLegRefID dest) nextFreeIdx xx.TradeLegRefID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:TradeCaptureReport_NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteTradeCaptureReport_NoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.TradeCaptureReport_NoLegsGrp  // end Option.fold
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteTrdRegTimestamps dest) nextFreeIdx xx.TrdRegTimestamps    // component option
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteMatchStatus dest) nextFreeIdx xx.MatchStatus
    let nextFreeIdx = Option.fold (WriteMatchType dest) nextFreeIdx xx.MatchType
    let noSidesField =  // ####
        match xx.TradeCaptureReport_NoSidesGrp with
        | OneOrTwo.One _ -> NoSides.OneSide
        | OneOrTwo.Two _ -> NoSides.BothSides
    let nextFreeIdx = WriteNoSides dest nextFreeIdx noSidesField
    let nextFreeIdx = xx.TradeCaptureReport_NoSidesGrp |> OneOrTwo.fold (WriteTradeCaptureReport_NoSidesGrp dest) nextFreeIdx  // group
    let nextFreeIdx = Option.fold (WriteCopyMsgIndicator dest) nextFreeIdx xx.CopyMsgIndicator
    let nextFreeIdx = Option.fold (WritePublishTrdIndicator dest) nextFreeIdx xx.PublishTrdIndicator
    let nextFreeIdx = Option.fold (WriteShortSaleReason dest) nextFreeIdx xx.ShortSaleReason
    nextFreeIdx


// tag: AR
let WriteTradeCaptureReportAck (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:TradeCaptureReportAck) = 
    let nextFreeIdx = WriteTradeReportID dest nextFreeIdx xx.TradeReportID
    let nextFreeIdx = Option.fold (WriteTradeReportTransType dest) nextFreeIdx xx.TradeReportTransType
    let nextFreeIdx = Option.fold (WriteTradeReportType dest) nextFreeIdx xx.TradeReportType
    let nextFreeIdx = Option.fold (WriteTrdType dest) nextFreeIdx xx.TrdType
    let nextFreeIdx = Option.fold (WriteTrdSubType dest) nextFreeIdx xx.TrdSubType
    let nextFreeIdx = Option.fold (WriteSecondaryTrdType dest) nextFreeIdx xx.SecondaryTrdType
    let nextFreeIdx = Option.fold (WriteTransferReason dest) nextFreeIdx xx.TransferReason
    let nextFreeIdx = WriteExecType dest nextFreeIdx xx.ExecType
    let nextFreeIdx = Option.fold (WriteTradeReportRefID dest) nextFreeIdx xx.TradeReportRefID
    let nextFreeIdx = Option.fold (WriteSecondaryTradeReportRefID dest) nextFreeIdx xx.SecondaryTradeReportRefID
    let nextFreeIdx = Option.fold (WriteTrdRptStatus dest) nextFreeIdx xx.TrdRptStatus
    let nextFreeIdx = Option.fold (WriteTradeReportRejectReason dest) nextFreeIdx xx.TradeReportRejectReason
    let nextFreeIdx = Option.fold (WriteSecondaryTradeReportID dest) nextFreeIdx xx.SecondaryTradeReportID
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    let nextFreeIdx = Option.fold (WriteTradeLinkID dest) nextFreeIdx xx.TradeLinkID
    let nextFreeIdx = Option.fold (WriteTrdMatchID dest) nextFreeIdx xx.TrdMatchID
    let nextFreeIdx = Option.fold (WriteExecID dest) nextFreeIdx xx.ExecID
    let nextFreeIdx = Option.fold (WriteSecondaryExecID dest) nextFreeIdx xx.SecondaryExecID
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteTrdRegTimestamps dest) nextFreeIdx xx.TrdRegTimestamps    // component option
    let nextFreeIdx = Option.fold (WriteResponseTransportType dest) nextFreeIdx xx.ResponseTransportType
    let nextFreeIdx = Option.fold (WriteResponseDestination dest) nextFreeIdx xx.ResponseDestination
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:TradeCaptureReportAck_NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteTradeCaptureReportAck_NoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.TradeCaptureReportAck_NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteClearingFeeIndicator dest) nextFreeIdx xx.ClearingFeeIndicator
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WriteOrderRestrictions dest) nextFreeIdx xx.OrderRestrictions
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WritePositionEffect dest) nextFreeIdx xx.PositionEffect
    let nextFreeIdx = Option.fold (WritePreallocMethod dest) nextFreeIdx xx.PreallocMethod
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:TradeCaptureReportAck_NoAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAllocs dest innerNextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteTradeCaptureReportAck_NoAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.TradeCaptureReportAck_NoAllocsGrp  // end Option.fold
    nextFreeIdx


// tag: o
let WriteRegistrationInstructions (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:RegistrationInstructions) = 
    let nextFreeIdx = WriteRegistID dest nextFreeIdx xx.RegistID
    let nextFreeIdx = WriteRegistTransType dest nextFreeIdx xx.RegistTransType
    let nextFreeIdx = WriteRegistRefID dest nextFreeIdx xx.RegistRefID
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteRegistAcctType dest) nextFreeIdx xx.RegistAcctType
    let nextFreeIdx = Option.fold (WriteTaxAdvantageType dest) nextFreeIdx xx.TaxAdvantageType
    let nextFreeIdx = Option.fold (WriteOwnershipType dest) nextFreeIdx xx.OwnershipType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoRegistDtlsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoRegistDtls dest innerNextFreeIdx (Fix44.Fields.NoRegistDtls numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoRegistDtlsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoRegistDtlsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoDistribInstsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoDistribInsts dest innerNextFreeIdx (Fix44.Fields.NoDistribInsts numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoDistribInstsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoDistribInstsGrp  // end Option.fold
    nextFreeIdx


// tag: p
let WriteRegistrationInstructionsResponse (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:RegistrationInstructionsResponse) = 
    let nextFreeIdx = WriteRegistID dest nextFreeIdx xx.RegistID
    let nextFreeIdx = WriteRegistTransType dest nextFreeIdx xx.RegistTransType
    let nextFreeIdx = WriteRegistRefID dest nextFreeIdx xx.RegistRefID
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = WriteRegistStatus dest nextFreeIdx xx.RegistStatus
    let nextFreeIdx = Option.fold (WriteRegistRejReasonCode dest) nextFreeIdx xx.RegistRejReasonCode
    let nextFreeIdx = Option.fold (WriteRegistRejReasonText dest) nextFreeIdx xx.RegistRejReasonText
    nextFreeIdx


// tag: AL
let WritePositionMaintenanceRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:PositionMaintenanceRequest) = 
    let nextFreeIdx = WritePosReqID dest nextFreeIdx xx.PosReqID
    let nextFreeIdx = WritePosTransType dest nextFreeIdx xx.PosTransType
    let nextFreeIdx = WritePosMaintAction dest nextFreeIdx xx.PosMaintAction
    let nextFreeIdx = Option.fold (WriteOrigPosReqRefID dest) nextFreeIdx xx.OrigPosReqRefID
    let nextFreeIdx = Option.fold (WritePosMaintRptRefID dest) nextFreeIdx xx.PosMaintRptRefID
    let nextFreeIdx = WriteClearingBusinessDate dest nextFreeIdx xx.ClearingBusinessDate
    let nextFreeIdx = Option.fold (WriteSettlSessID dest) nextFreeIdx xx.SettlSessID
    let nextFreeIdx = Option.fold (WriteSettlSessSubID dest) nextFreeIdx xx.SettlSessSubID
    let nextFreeIdx = WriteParties dest nextFreeIdx xx.Parties   // component
    let nextFreeIdx = WriteAccount dest nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = WriteAccountType dest nextFreeIdx xx.AccountType
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradingSessionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTradingSessions dest innerNextFreeIdx (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradingSessionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradingSessionsGrp  // end Option.fold
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = WritePositionQty dest nextFreeIdx xx.PositionQty   // component
    let nextFreeIdx = Option.fold (WriteAdjustmentType dest) nextFreeIdx xx.AdjustmentType
    let nextFreeIdx = Option.fold (WriteContraryInstructionIndicator dest) nextFreeIdx xx.ContraryInstructionIndicator
    let nextFreeIdx = Option.fold (WritePriorSpreadIndicator dest) nextFreeIdx xx.PriorSpreadIndicator
    let nextFreeIdx = Option.fold (WriteThresholdAmount dest) nextFreeIdx xx.ThresholdAmount
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AM
let WritePositionMaintenanceReport (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:PositionMaintenanceReport) = 
    let nextFreeIdx = WritePosMaintRptID dest nextFreeIdx xx.PosMaintRptID
    let nextFreeIdx = WritePosTransType dest nextFreeIdx xx.PosTransType
    let nextFreeIdx = Option.fold (WritePosReqID dest) nextFreeIdx xx.PosReqID
    let nextFreeIdx = WritePosMaintAction dest nextFreeIdx xx.PosMaintAction
    let nextFreeIdx = WriteOrigPosReqRefID dest nextFreeIdx xx.OrigPosReqRefID
    let nextFreeIdx = WritePosMaintStatus dest nextFreeIdx xx.PosMaintStatus
    let nextFreeIdx = Option.fold (WritePosMaintResult dest) nextFreeIdx xx.PosMaintResult
    let nextFreeIdx = WriteClearingBusinessDate dest nextFreeIdx xx.ClearingBusinessDate
    let nextFreeIdx = Option.fold (WriteSettlSessID dest) nextFreeIdx xx.SettlSessID
    let nextFreeIdx = Option.fold (WriteSettlSessSubID dest) nextFreeIdx xx.SettlSessSubID
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = WriteAccount dest nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = WriteAccountType dest nextFreeIdx xx.AccountType
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradingSessionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTradingSessions dest innerNextFreeIdx (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradingSessionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradingSessionsGrp  // end Option.fold
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = WritePositionQty dest nextFreeIdx xx.PositionQty   // component
    let nextFreeIdx = WritePositionAmountData dest nextFreeIdx xx.PositionAmountData   // component
    let nextFreeIdx = Option.fold (WriteAdjustmentType dest) nextFreeIdx xx.AdjustmentType
    let nextFreeIdx = Option.fold (WriteThresholdAmount dest) nextFreeIdx xx.ThresholdAmount
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AN
let WriteRequestForPositions (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:RequestForPositions) = 
    let nextFreeIdx = WritePosReqID dest nextFreeIdx xx.PosReqID
    let nextFreeIdx = WritePosReqType dest nextFreeIdx xx.PosReqType
    let nextFreeIdx = Option.fold (WriteMatchStatus dest) nextFreeIdx xx.MatchStatus
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    let nextFreeIdx = WriteParties dest nextFreeIdx xx.Parties   // component
    let nextFreeIdx = WriteAccount dest nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = WriteAccountType dest nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = WriteClearingBusinessDate dest nextFreeIdx xx.ClearingBusinessDate
    let nextFreeIdx = Option.fold (WriteSettlSessID dest) nextFreeIdx xx.SettlSessID
    let nextFreeIdx = Option.fold (WriteSettlSessSubID dest) nextFreeIdx xx.SettlSessSubID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradingSessionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTradingSessions dest innerNextFreeIdx (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradingSessionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradingSessionsGrp  // end Option.fold
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteResponseTransportType dest) nextFreeIdx xx.ResponseTransportType
    let nextFreeIdx = Option.fold (WriteResponseDestination dest) nextFreeIdx xx.ResponseDestination
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AO
let WriteRequestForPositionsAck (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:RequestForPositionsAck) = 
    let nextFreeIdx = WritePosMaintRptID dest nextFreeIdx xx.PosMaintRptID
    let nextFreeIdx = Option.fold (WritePosReqID dest) nextFreeIdx xx.PosReqID
    let nextFreeIdx = Option.fold (WriteTotalNumPosReports dest) nextFreeIdx xx.TotalNumPosReports
    let nextFreeIdx = Option.fold (WriteUnsolicitedIndicator dest) nextFreeIdx xx.UnsolicitedIndicator
    let nextFreeIdx = WritePosReqResult dest nextFreeIdx xx.PosReqResult
    let nextFreeIdx = WritePosReqStatus dest nextFreeIdx xx.PosReqStatus
    let nextFreeIdx = WriteParties dest nextFreeIdx xx.Parties   // component
    let nextFreeIdx = WriteAccount dest nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = WriteAccountType dest nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteResponseTransportType dest) nextFreeIdx xx.ResponseTransportType
    let nextFreeIdx = Option.fold (WriteResponseDestination dest) nextFreeIdx xx.ResponseDestination
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AP
let WritePositionReport (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:PositionReport) = 
    let nextFreeIdx = WritePosMaintRptID dest nextFreeIdx xx.PosMaintRptID
    let nextFreeIdx = Option.fold (WritePosReqID dest) nextFreeIdx xx.PosReqID
    let nextFreeIdx = Option.fold (WritePosReqType dest) nextFreeIdx xx.PosReqType
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    let nextFreeIdx = Option.fold (WriteTotalNumPosReports dest) nextFreeIdx xx.TotalNumPosReports
    let nextFreeIdx = Option.fold (WriteUnsolicitedIndicator dest) nextFreeIdx xx.UnsolicitedIndicator
    let nextFreeIdx = WritePosReqResult dest nextFreeIdx xx.PosReqResult
    let nextFreeIdx = WriteClearingBusinessDate dest nextFreeIdx xx.ClearingBusinessDate
    let nextFreeIdx = Option.fold (WriteSettlSessID dest) nextFreeIdx xx.SettlSessID
    let nextFreeIdx = Option.fold (WriteSettlSessSubID dest) nextFreeIdx xx.SettlSessSubID
    let nextFreeIdx = WriteParties dest nextFreeIdx xx.Parties   // component
    let nextFreeIdx = WriteAccount dest nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = WriteAccountType dest nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = WriteSettlPrice dest nextFreeIdx xx.SettlPrice
    let nextFreeIdx = WriteSettlPriceType dest nextFreeIdx xx.SettlPriceType
    let nextFreeIdx = WritePriorSettlPrice dest nextFreeIdx xx.PriorSettlPrice
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:PositionReport_NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WritePositionReport_NoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.PositionReport_NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = WritePositionQty dest nextFreeIdx xx.PositionQty   // component
    let nextFreeIdx = WritePositionAmountData dest nextFreeIdx xx.PositionAmountData   // component
    let nextFreeIdx = Option.fold (WriteRegistStatus dest) nextFreeIdx xx.RegistStatus
    let nextFreeIdx = Option.fold (WriteDeliveryDate dest) nextFreeIdx xx.DeliveryDate
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AW
let WriteAssignmentReport (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:AssignmentReport) = 
    let nextFreeIdx = WriteAsgnRptID dest nextFreeIdx xx.AsgnRptID
    let nextFreeIdx = Option.fold (WriteTotNumAssignmentReports dest) nextFreeIdx xx.TotNumAssignmentReports
    let nextFreeIdx = Option.fold (WriteLastRptRequested dest) nextFreeIdx xx.LastRptRequested
    let nextFreeIdx = WriteParties dest nextFreeIdx xx.Parties   // component
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = WriteAccountType dest nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteNoLegs dest) nextFreeIdx xx.NoLegs
    let nextFreeIdx = Option.fold (WriteInstrumentLeg dest) nextFreeIdx xx.InstrumentLeg    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = WritePositionQty dest nextFreeIdx xx.PositionQty   // component
    let nextFreeIdx = WritePositionAmountData dest nextFreeIdx xx.PositionAmountData   // component
    let nextFreeIdx = Option.fold (WriteThresholdAmount dest) nextFreeIdx xx.ThresholdAmount
    let nextFreeIdx = WriteSettlPrice dest nextFreeIdx xx.SettlPrice
    let nextFreeIdx = WriteSettlPriceType dest nextFreeIdx xx.SettlPriceType
    let nextFreeIdx = WriteUnderlyingSettlPrice dest nextFreeIdx xx.UnderlyingSettlPrice
    let nextFreeIdx = Option.fold (WriteExpireDate dest) nextFreeIdx xx.ExpireDate
    let nextFreeIdx = WriteAssignmentMethod dest nextFreeIdx xx.AssignmentMethod
    let nextFreeIdx = Option.fold (WriteAssignmentUnit dest) nextFreeIdx xx.AssignmentUnit
    let nextFreeIdx = WriteOpenInterest dest nextFreeIdx xx.OpenInterest
    let nextFreeIdx = WriteExerciseMethod dest nextFreeIdx xx.ExerciseMethod
    let nextFreeIdx = WriteSettlSessID dest nextFreeIdx xx.SettlSessID
    let nextFreeIdx = WriteSettlSessSubID dest nextFreeIdx xx.SettlSessSubID
    let nextFreeIdx = WriteClearingBusinessDate dest nextFreeIdx xx.ClearingBusinessDate
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AX
let WriteCollateralRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:CollateralRequest) = 
    let nextFreeIdx = WriteCollReqID dest nextFreeIdx xx.CollReqID
    let nextFreeIdx = WriteCollAsgnReason dest nextFreeIdx xx.CollAsgnReason
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteSecondaryOrderID dest) nextFreeIdx xx.SecondaryOrderID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoExecsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoExecs dest innerNextFreeIdx (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoExecsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoExecsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTrades dest innerNextFreeIdx (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteQuantity dest) nextFreeIdx xx.Quantity
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteNoLegs dest) nextFreeIdx xx.NoLegs
    let nextFreeIdx = Option.fold (WriteInstrumentLeg dest) nextFreeIdx xx.InstrumentLeg    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:CollateralRequest_NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteCollateralRequest_NoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.CollateralRequest_NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteMarginExcess dest) nextFreeIdx xx.MarginExcess
    let nextFreeIdx = Option.fold (WriteTotalNetValue dest) nextFreeIdx xx.TotalNetValue
    let nextFreeIdx = Option.fold (WriteCashOutstanding dest) nextFreeIdx xx.CashOutstanding
    let nextFreeIdx = Option.fold (WriteTrdRegTimestamps dest) nextFreeIdx xx.TrdRegTimestamps    // component option
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoMiscFeesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoMiscFees dest innerNextFreeIdx (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoMiscFeesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoMiscFeesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WriteAccruedInterestAmt dest) nextFreeIdx xx.AccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteEndAccruedInterestAmt dest) nextFreeIdx xx.EndAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteStartCash dest) nextFreeIdx xx.StartCash
    let nextFreeIdx = Option.fold (WriteEndCash dest) nextFreeIdx xx.EndCash
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteSettlSessID dest) nextFreeIdx xx.SettlSessID
    let nextFreeIdx = Option.fold (WriteSettlSessSubID dest) nextFreeIdx xx.SettlSessSubID
    let nextFreeIdx = Option.fold (WriteClearingBusinessDate dest) nextFreeIdx xx.ClearingBusinessDate
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AY
let WriteCollateralAssignment (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:CollateralAssignment) = 
    let nextFreeIdx = WriteCollAsgnID dest nextFreeIdx xx.CollAsgnID
    let nextFreeIdx = Option.fold (WriteCollReqID dest) nextFreeIdx xx.CollReqID
    let nextFreeIdx = WriteCollAsgnReason dest nextFreeIdx xx.CollAsgnReason
    let nextFreeIdx = WriteCollAsgnTransType dest nextFreeIdx xx.CollAsgnTransType
    let nextFreeIdx = Option.fold (WriteCollAsgnRefID dest) nextFreeIdx xx.CollAsgnRefID
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteSecondaryOrderID dest) nextFreeIdx xx.SecondaryOrderID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoExecsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoExecs dest innerNextFreeIdx (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoExecsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoExecsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTrades dest innerNextFreeIdx (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteQuantity dest) nextFreeIdx xx.Quantity
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteNoLegs dest) nextFreeIdx xx.NoLegs
    let nextFreeIdx = Option.fold (WriteInstrumentLeg dest) nextFreeIdx xx.InstrumentLeg    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:CollateralAssignment_NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteCollateralAssignment_NoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.CollateralAssignment_NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteMarginExcess dest) nextFreeIdx xx.MarginExcess
    let nextFreeIdx = Option.fold (WriteTotalNetValue dest) nextFreeIdx xx.TotalNetValue
    let nextFreeIdx = Option.fold (WriteCashOutstanding dest) nextFreeIdx xx.CashOutstanding
    let nextFreeIdx = Option.fold (WriteTrdRegTimestamps dest) nextFreeIdx xx.TrdRegTimestamps    // component option
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoMiscFeesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoMiscFees dest innerNextFreeIdx (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoMiscFeesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoMiscFeesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WriteAccruedInterestAmt dest) nextFreeIdx xx.AccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteEndAccruedInterestAmt dest) nextFreeIdx xx.EndAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteStartCash dest) nextFreeIdx xx.StartCash
    let nextFreeIdx = Option.fold (WriteEndCash dest) nextFreeIdx xx.EndCash
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = Option.fold (WriteSettlInstructionsData dest) nextFreeIdx xx.SettlInstructionsData    // component option
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteSettlSessID dest) nextFreeIdx xx.SettlSessID
    let nextFreeIdx = Option.fold (WriteSettlSessSubID dest) nextFreeIdx xx.SettlSessSubID
    let nextFreeIdx = Option.fold (WriteClearingBusinessDate dest) nextFreeIdx xx.ClearingBusinessDate
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: AZ
let WriteCollateralResponse (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:CollateralResponse) = 
    let nextFreeIdx = WriteCollRespID dest nextFreeIdx xx.CollRespID
    let nextFreeIdx = WriteCollAsgnID dest nextFreeIdx xx.CollAsgnID
    let nextFreeIdx = Option.fold (WriteCollReqID dest) nextFreeIdx xx.CollReqID
    let nextFreeIdx = WriteCollAsgnReason dest nextFreeIdx xx.CollAsgnReason
    let nextFreeIdx = Option.fold (WriteCollAsgnTransType dest) nextFreeIdx xx.CollAsgnTransType
    let nextFreeIdx = WriteCollAsgnRespType dest nextFreeIdx xx.CollAsgnRespType
    let nextFreeIdx = Option.fold (WriteCollAsgnRejectReason dest) nextFreeIdx xx.CollAsgnRejectReason
    let nextFreeIdx = WriteTransactTime dest nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteSecondaryOrderID dest) nextFreeIdx xx.SecondaryOrderID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoExecsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoExecs dest innerNextFreeIdx (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoExecsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoExecsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTrades dest innerNextFreeIdx (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteQuantity dest) nextFreeIdx xx.Quantity
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteNoLegs dest) nextFreeIdx xx.NoLegs
    let nextFreeIdx = Option.fold (WriteInstrumentLeg dest) nextFreeIdx xx.InstrumentLeg    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:CollateralResponse_NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteCollateralResponse_NoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.CollateralResponse_NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteMarginExcess dest) nextFreeIdx xx.MarginExcess
    let nextFreeIdx = Option.fold (WriteTotalNetValue dest) nextFreeIdx xx.TotalNetValue
    let nextFreeIdx = Option.fold (WriteCashOutstanding dest) nextFreeIdx xx.CashOutstanding
    let nextFreeIdx = Option.fold (WriteTrdRegTimestamps dest) nextFreeIdx xx.TrdRegTimestamps    // component option
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoMiscFeesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoMiscFees dest innerNextFreeIdx (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoMiscFeesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoMiscFeesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WriteAccruedInterestAmt dest) nextFreeIdx xx.AccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteEndAccruedInterestAmt dest) nextFreeIdx xx.EndAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteStartCash dest) nextFreeIdx xx.StartCash
    let nextFreeIdx = Option.fold (WriteEndCash dest) nextFreeIdx xx.EndCash
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: BA
let WriteCollateralReport (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:CollateralReport) = 
    let nextFreeIdx = WriteCollRptID dest nextFreeIdx xx.CollRptID
    let nextFreeIdx = Option.fold (WriteCollInquiryID dest) nextFreeIdx xx.CollInquiryID
    let nextFreeIdx = WriteCollStatus dest nextFreeIdx xx.CollStatus
    let nextFreeIdx = Option.fold (WriteTotNumReports dest) nextFreeIdx xx.TotNumReports
    let nextFreeIdx = Option.fold (WriteLastRptRequested dest) nextFreeIdx xx.LastRptRequested
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteSecondaryOrderID dest) nextFreeIdx xx.SecondaryOrderID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoExecsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoExecs dest innerNextFreeIdx (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoExecsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoExecsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTrades dest innerNextFreeIdx (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteQuantity dest) nextFreeIdx xx.Quantity
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteNoLegs dest) nextFreeIdx xx.NoLegs
    let nextFreeIdx = Option.fold (WriteInstrumentLeg dest) nextFreeIdx xx.InstrumentLeg    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteMarginExcess dest) nextFreeIdx xx.MarginExcess
    let nextFreeIdx = Option.fold (WriteTotalNetValue dest) nextFreeIdx xx.TotalNetValue
    let nextFreeIdx = Option.fold (WriteCashOutstanding dest) nextFreeIdx xx.CashOutstanding
    let nextFreeIdx = Option.fold (WriteTrdRegTimestamps dest) nextFreeIdx xx.TrdRegTimestamps    // component option
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoMiscFeesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoMiscFees dest innerNextFreeIdx (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoMiscFeesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoMiscFeesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WriteAccruedInterestAmt dest) nextFreeIdx xx.AccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteEndAccruedInterestAmt dest) nextFreeIdx xx.EndAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteStartCash dest) nextFreeIdx xx.StartCash
    let nextFreeIdx = Option.fold (WriteEndCash dest) nextFreeIdx xx.EndCash
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = Option.fold (WriteSettlInstructionsData dest) nextFreeIdx xx.SettlInstructionsData    // component option
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteSettlSessID dest) nextFreeIdx xx.SettlSessID
    let nextFreeIdx = Option.fold (WriteSettlSessSubID dest) nextFreeIdx xx.SettlSessSubID
    let nextFreeIdx = Option.fold (WriteClearingBusinessDate dest) nextFreeIdx xx.ClearingBusinessDate
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: BB
let WriteCollateralInquiry (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:CollateralInquiry) = 
    let nextFreeIdx = Option.fold (WriteCollInquiryID dest) nextFreeIdx xx.CollInquiryID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoCollInquiryQualifierGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoCollInquiryQualifier dest innerNextFreeIdx (Fix44.Fields.NoCollInquiryQualifier numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoCollInquiryQualifierGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoCollInquiryQualifierGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSubscriptionRequestType dest) nextFreeIdx xx.SubscriptionRequestType
    let nextFreeIdx = Option.fold (WriteResponseTransportType dest) nextFreeIdx xx.ResponseTransportType
    let nextFreeIdx = Option.fold (WriteResponseDestination dest) nextFreeIdx xx.ResponseDestination
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteSecondaryOrderID dest) nextFreeIdx xx.SecondaryOrderID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoExecsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoExecs dest innerNextFreeIdx (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoExecsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoExecsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTrades dest innerNextFreeIdx (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteQuantity dest) nextFreeIdx xx.Quantity
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteNoLegs dest) nextFreeIdx xx.NoLegs
    let nextFreeIdx = Option.fold (WriteInstrumentLeg dest) nextFreeIdx xx.InstrumentLeg    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteMarginExcess dest) nextFreeIdx xx.MarginExcess
    let nextFreeIdx = Option.fold (WriteTotalNetValue dest) nextFreeIdx xx.TotalNetValue
    let nextFreeIdx = Option.fold (WriteCashOutstanding dest) nextFreeIdx xx.CashOutstanding
    let nextFreeIdx = Option.fold (WriteTrdRegTimestamps dest) nextFreeIdx xx.TrdRegTimestamps    // component option
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WriteAccruedInterestAmt dest) nextFreeIdx xx.AccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteEndAccruedInterestAmt dest) nextFreeIdx xx.EndAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteStartCash dest) nextFreeIdx xx.StartCash
    let nextFreeIdx = Option.fold (WriteEndCash dest) nextFreeIdx xx.EndCash
    let nextFreeIdx = Option.fold (WriteSpreadOrBenchmarkCurveData dest) nextFreeIdx xx.SpreadOrBenchmarkCurveData    // component option
    let nextFreeIdx = Option.fold (WriteStipulations dest) nextFreeIdx xx.Stipulations    // component option
    let nextFreeIdx = Option.fold (WriteSettlInstructionsData dest) nextFreeIdx xx.SettlInstructionsData    // component option
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteSettlSessID dest) nextFreeIdx xx.SettlSessID
    let nextFreeIdx = Option.fold (WriteSettlSessSubID dest) nextFreeIdx xx.SettlSessSubID
    let nextFreeIdx = Option.fold (WriteClearingBusinessDate dest) nextFreeIdx xx.ClearingBusinessDate
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// tag: BC
let WriteNetworkStatusRequest (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:NetworkStatusRequest) = 
    let nextFreeIdx = WriteNetworkRequestType dest nextFreeIdx xx.NetworkRequestType
    let nextFreeIdx = WriteNetworkRequestID dest nextFreeIdx xx.NetworkRequestID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoCompIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoCompIDs dest innerNextFreeIdx (Fix44.Fields.NoCompIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoCompIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoCompIDsGrp  // end Option.fold
    nextFreeIdx


// tag: BD
let WriteNetworkStatusResponse (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:NetworkStatusResponse) = 
    let nextFreeIdx = WriteNetworkStatusResponseType dest nextFreeIdx xx.NetworkStatusResponseType
    let nextFreeIdx = Option.fold (WriteNetworkRequestID dest) nextFreeIdx xx.NetworkRequestID
    let nextFreeIdx = Option.fold (WriteNetworkResponseID dest) nextFreeIdx xx.NetworkResponseID
    let nextFreeIdx = Option.fold (WriteLastNetworkResponseID dest) nextFreeIdx xx.LastNetworkResponseID
    let numGrps = xx.NetworkStatusResponse_NoCompIDsGrp.Length
    let nextFreeIdx = WriteNoCompIDs dest nextFreeIdx (Fix44.Fields.NoCompIDs numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NetworkStatusResponse_NoCompIDsGrp |> List.fold (fun accFreeIdx gg -> WriteNetworkStatusResponse_NoCompIDsGrp dest accFreeIdx gg) nextFreeIdx
    nextFreeIdx


// tag: BG
let WriteCollateralInquiryAck (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:CollateralInquiryAck) = 
    let nextFreeIdx = WriteCollInquiryID dest nextFreeIdx xx.CollInquiryID
    let nextFreeIdx = WriteCollInquiryStatus dest nextFreeIdx xx.CollInquiryStatus
    let nextFreeIdx = Option.fold (WriteCollInquiryResult dest) nextFreeIdx xx.CollInquiryResult
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoCollInquiryQualifierGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoCollInquiryQualifier dest innerNextFreeIdx (Fix44.Fields.NoCollInquiryQualifier numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoCollInquiryQualifierGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoCollInquiryQualifierGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteTotNumReports dest) nextFreeIdx xx.TotNumReports
    let nextFreeIdx = Option.fold (WriteParties dest) nextFreeIdx xx.Parties    // component option
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteSecondaryOrderID dest) nextFreeIdx xx.SecondaryOrderID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoExecsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoExecs dest innerNextFreeIdx (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoExecsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoExecsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTrades dest innerNextFreeIdx (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    let nextFreeIdx = Option.fold (WriteFinancingDetails dest) nextFreeIdx xx.FinancingDetails    // component option
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteQuantity dest) nextFreeIdx xx.Quantity
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteNoLegs dest) nextFreeIdx xx.NoLegs
    let nextFreeIdx = Option.fold (WriteInstrumentLeg dest) nextFreeIdx xx.InstrumentLeg    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteSettlSessID dest) nextFreeIdx xx.SettlSessID
    let nextFreeIdx = Option.fold (WriteSettlSessSubID dest) nextFreeIdx xx.SettlSessSubID
    let nextFreeIdx = Option.fold (WriteClearingBusinessDate dest) nextFreeIdx xx.ClearingBusinessDate
    let nextFreeIdx = Option.fold (WriteResponseTransportType dest) nextFreeIdx xx.ResponseTransportType
    let nextFreeIdx = Option.fold (WriteResponseDestination dest) nextFreeIdx xx.ResponseDestination
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


