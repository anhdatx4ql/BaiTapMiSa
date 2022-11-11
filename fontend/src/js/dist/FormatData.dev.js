"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.FormatDate = FormatDate;
exports.FormatDatePost = FormatDatePost;
exports.IsEmpty = IsEmpty;
exports.ucFirst = ucFirst;

var _moment = _interopRequireDefault(require("moment"));

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { "default": obj }; }

/**
 * Author: Phạm Văn Đạt
 * function: format ngày tháng năm
 * created: 20:15 20/08/2022
 */
function FormatDate(value) {
  return (0, _moment["default"])(String(value)).format('YYYY-MM-DD');
}
/**
 * Author: Phạm Văn Đạt
 * function: format ngày tháng năm post
 * created: 20:20 20/08/2022
 */


function FormatDatePost(value) {
  return (0, _moment["default"])(String(value)).format('YYYY-MM-DDTHH:mm:ss');
}
/**
 * Author: Phạm Văn Đạt
 * function: Kiểm tra null
 * created: 20:30 20/08/2022
 */


function IsEmpty(value) {
  return value == null // NULL value
  || value == undefined // undefined
  || value == 'undefined' // undefined
  || value.length == 0 // Array is empty
  || value == '00000000-0000-0000-0000-000000000000' // Guid empty
  || value instanceof Date && !isNaN(value.valueOf()) && ( // Validate DateTime value and check min-max value
  value <= new Date("1753, 01, 01") || // SQL DateTime minimum value
  value >= new Date("9999, 12, 31, 23, 59, 59, 999")) // SQL DateTime maximum value
  ;
}
/**
 * Author: Phạm Văn Đạt(10/11/2022)
 * Function: Xử lý in hoa chữ cái đầu 
 */


function ucFirst(string) {
  return string.charAt(0).toUpperCase() + string.slice(1).toLowerCase();
}