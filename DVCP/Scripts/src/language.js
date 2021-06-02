/**
 * @Project NUKEVIET 4.x
 * @Author  VINADES.,JSC (contact@vinades.vn)
 * @Copyright (C) 2014 VINADES.,JSC. All rights reserved
 * @License GNU/GPL version 2 or any later version
 * @Createdate 3-13-2010 15:24
 */

 var nv_aryDayName = new Array('Chá»§ nháº­t', 'Thá»© Hai', 'Thá»© Ba', 'Thá»© TÆ°', 'Thá»© NÄƒm', 'Thá»© SĂ¡u', 'Thá»© Báº£y');
 var nv_aryDayNS = new Array('CN', 'Hai', 'Ba', 'TÆ°', 'NÄƒm', 'SĂ¡u', 'Báº£y');
 var nv_aryMonth = new Array('ThĂ¡ng Má»™t', 'ThĂ¡ng Hai', 'ThĂ¡ng Ba', 'ThĂ¡ng TÆ°', 'ThĂ¡ng NÄƒm', 'ThĂ¡ng SĂ¡u', 'ThĂ¡ng Báº£y', 'ThĂ¡ng TĂ¡m', 'ThĂ¡ng ChĂ­n', 'ThĂ¡ng MÆ°á»i', 'ThĂ¡ng MÆ°á»i má»™t', 'ThĂ¡ng MÆ°á»i hai');
 var nv_aryMS = new Array('ThĂ¡ng 1', 'ThĂ¡ng 2', 'ThĂ¡ng 3', 'ThĂ¡ng 4', 'ThĂ¡ng 5', 'ThĂ¡ng 6', 'ThĂ¡ng 7', 'ThĂ¡ng 8', 'ThĂ¡ng 9', 'ThĂ¡ng 10', 'ThĂ¡ng 11', 'ThĂ¡ng 12');
 var nv_admlogout_confirm = new Array('Báº¡n thá»±c sá»± muá»‘n thoĂ¡t khá»i tĂ i khoáº£n Quáº£n trá»‹?', 'ToĂ n bá»™ thĂ´ng tin Ä‘Äƒng nháº­p Ä‘Ă£ Ä‘Æ°á»£c xĂ³a. Báº¡n Ä‘Ă£ thoĂ¡t khá»i tĂ i khoáº£n Quáº£n trá»‹');
 var nv_is_del_confirm = new Array('Báº¡n thá»±c sá»± muá»‘n xĂ³a? Náº¿u Ä‘á»“ng Ă½, táº¥t cáº£ dá»¯ liá»‡u liĂªn quan sáº½ bá»‹ xĂ³a. Báº¡n sáº½ khĂ´ng thá»ƒ phá»¥c há»“i láº¡i chĂºng sau nĂ y', 'Lá»‡nh XĂ³a Ä‘Ă£ Ä‘Æ°á»£c thá»±c hiá»‡n', 'VĂ¬ má»™t lĂ½ do nĂ o Ä‘Ă³ lá»‡nh XĂ³a Ä‘Ă£ khĂ´ng Ä‘Æ°á»£c thá»±c hiá»‡n');
 var nv_is_change_act_confirm = new Array('Báº¡n thá»±c sá»± muá»‘n thá»±c hiá»‡n lá»‡nh \'Thay Ä‘á»•i\'?', 'Lá»‡nh \'Thay Ä‘á»•i\' Ä‘Ă£ Ä‘Æ°á»£c thá»±c hiá»‡n', 'VĂ¬ má»™t lĂ½ do nĂ o Ä‘Ă³ lá»‡nh \'Thay Ä‘á»•i\' Ä‘Ă£ khĂ´ng Ä‘Æ°á»£c thá»±c hiá»‡n');
 var nv_is_empty_confirm = new Array('Báº¡n thá»±c sá»± muá»‘n thá»±c hiá»‡n lá»‡nh \'LĂ m rá»—ng\'?', 'Lá»‡nh \'LĂ m rá»—ng\' Ä‘Ă£ Ä‘Æ°á»£c thá»±c hiá»‡n', 'VĂ¬ má»™t lĂ½ do nĂ o Ä‘Ă³ lá»‡nh \'LĂ m rá»—ng\' Ä‘Ă£ khĂ´ng Ä‘Æ°á»£c thá»±c hiá»‡n');
 var nv_is_recreate_confirm = new Array('Báº¡n thá»±c sá»± muá»‘n thá»±c hiá»‡n lá»‡nh \'CĂ i láº¡i\'?', 'Lá»‡nh \'CĂ i láº¡i\' Ä‘Ă£ Ä‘Æ°á»£c thá»±c hiá»‡n', 'VĂ¬ má»™t lĂ½ do nĂ o Ä‘Ă³ lá»‡nh \'CĂ i láº¡i\' Ä‘Ă£ khĂ´ng Ä‘Æ°á»£c thá»±c hiá»‡n');
 var nv_is_add_user_confirm = new Array('Báº¡n thá»±c sá»± muá»‘n thĂªm thĂ nh viĂªn nĂ y vĂ o nhĂ³m?', 'Lá»‡nh \'ThĂªm vĂ o nhĂ³m\' Ä‘Ă£ Ä‘Æ°á»£c thá»±c hiá»‡n', 'VĂ¬ má»™t lĂ½ do nĂ o Ä‘Ă³ lá»‡nh \'ThĂªm vĂ o nhĂ³m\' Ä‘Ă£ khĂ´ng Ä‘Æ°á»£c thá»±c hiá»‡n');
 var nv_is_exclude_user_confirm = new Array('Báº¡n thá»±c sá»± muá»‘n loáº¡i thĂ nh viĂªn nĂ y ra khá»i nhĂ³m?', 'Lá»‡nh \'Loáº¡i khá»i nhĂ³m\' Ä‘Ă£ Ä‘Æ°á»£c thá»±c hiá»‡n', 'VĂ¬ má»™t lĂ½ do nĂ o Ä‘Ă³ lá»‡nh \'Loáº¡i khá»i nhĂ³m\' Ä‘Ă£ khĂ´ng Ä‘Æ°á»£c thá»±c hiá»‡n');
 
 var nv_formatString = "dd.mm.yyyy";
 var nv_gotoString = "Chá»n thĂ¡ng hiá»‡n táº¡i";
 var nv_todayString = "HĂ´m nay";
 var nv_weekShortString = "Tuáº§n";
 var nv_weekString = "Tuáº§n";
 var nv_scrollLeftMessage = "Click Ä‘á»ƒ di chuyá»ƒn Ä‘áº¿n thĂ¡ng trÆ°á»›c. Giá»¯ chuá»™t Ä‘á»ƒ di chuyá»ƒn tá»± Ä‘á»™ng.";
 var nv_scrollRightMessage = "Click Ä‘á»ƒ di chuyá»ƒn Ä‘áº¿n thĂ¡ng sau. Giá»¯ chuá»™t Ä‘á»ƒ di chuyá»ƒn tá»± Ä‘á»™ng.";
 var nv_selectMonthMessage = "Click Ä‘á»ƒ chá»n thĂ¡ng.";
 var nv_selectYearMessage = "Click Ä‘á»ƒ chá»n nÄƒm.";
 var nv_selectDateMessage = "Chá»n ngĂ y [date].";
 
 var nv_loadingText = "Äang táº£i...";
 var nv_loadingTitle = "Click Ä‘á»ƒ thĂ´i";
 var nv_focusTitle = "Click Ä‘á»ƒ xem tiáº¿p";
 var nv_fullExpandTitle = "Má»Ÿ rá»™ng kĂ­ch thÆ°á»›c thá»±c táº¿ (f)";
 var nv_restoreTitle = "Click Ä‘á»ƒ Ä‘Ă³ng hĂ¬nh áº£nh, Click vĂ  kĂ©o Ä‘á»ƒ di chuyá»ƒn. Sá»­ dá»¥ng phĂ­m mÅ©i tĂªn Tiáº¿p theo vĂ  Quay láº¡i.";
 
 var nv_error_login = "Lá»—i: Báº¡n chÆ°a khai bĂ¡o tĂ i khoáº£n hoáº·c khai bĂ¡o khĂ´ng Ä‘Ăºng. TĂ i khoáº£n pháº£i bao gá»“m nhá»¯ng kĂ½ tá»± cĂ³ trong báº£ng chá»¯ cĂ¡i latin, sá»‘ vĂ  dáº¥u gáº¡ch dÆ°á»›i. Sá»‘ kĂ½ tá»± tá»‘i Ä‘a lĂ  [max], tá»‘i thiá»ƒu lĂ  [min]";
 var nv_error_password = "Lá»—i: Báº¡n chÆ°a khai bĂ¡o máº­t kháº©u hoáº·c khai bĂ¡o khĂ´ng Ä‘Ăºng. Máº­t kháº©u pháº£i bao gá»“m nhá»¯ng kĂ½ tá»± cĂ³ trong báº£ng chá»¯ cĂ¡i latin, sá»‘ vĂ  dáº¥u gáº¡ch dÆ°á»›i. Sá»‘ kĂ½ tá»± tá»‘i Ä‘a lĂ  [max], tá»‘i thiá»ƒu lĂ  [min]";
 var nv_error_email = "Lá»—i: Báº¡n chÆ°a khai bĂ¡o Ä‘á»‹a chá»‰ há»™p thÆ° Ä‘iá»‡n tá»­ hoáº·c khai bĂ¡o khĂ´ng Ä‘Ăºng quy Ä‘á»‹nh";
 var nv_error_seccode = "Lá»—i: Báº¡n chÆ°a khai bĂ¡o MĂ£ báº£o máº­t hoáº·c khai bĂ¡o khĂ´ng Ä‘Ăºng. MĂ£ báº£o máº­t pháº£i lĂ  má»™t dĂ£y sá»‘ cĂ³ chiá»u dĂ i lĂ  [num] kĂ½ tá»± Ä‘Æ°á»£c thá»ƒ hiá»‡n trong hĂ¬nh bĂªn";
 var nv_login_failed = "Lá»—i: VĂ¬ má»™t lĂ½ do nĂ o Ä‘Ă³, há»‡ thá»‘ng khĂ´ng tiáº¿p nháº­n tĂ i khoáº£n cá»§a báº¡n. HĂ£y thá»­ khai bĂ¡o láº¡i láº§n ná»¯a";
 var nv_content_failed = "Lá»—i: VĂ¬ má»™t lĂ½ do nĂ o Ä‘Ă³, há»‡ thá»‘ng khĂ´ng tiáº¿p nháº­n thĂ´ng tin cá»§a báº¡n. HĂ£y thá»­ khai bĂ¡o láº¡i láº§n ná»¯a";
 
 var nv_required = "TrÆ°á»ng nĂ y lĂ  báº¯t buá»™c.";
 var nv_remote = "Xin vui lĂ²ng sá»­a chá»¯a trÆ°á»ng nĂ y.";
 var nv_email = "Xin vui lĂ²ng nháº­p Ä‘á»‹a chá»‰ email há»£p lá»‡.";
 var nv_url = "Xin vui lĂ²ng nháº­p URL há»£p lá»‡.";
 var nv_date = "Xin vui lĂ²ng nháº­p ngĂ y há»£p lá»‡.";
 var nv_dateISO = "Xin vui lĂ²ng nháº­p ngĂ y há»£p lá»‡ (ISO).";
 var nv_number = "Xin vui lĂ²ng nháº­p sá»‘ há»£p lá»‡.";
 var nv_digits = "Xin vui lĂ²ng nháº­p chá»‰ chá»¯ sá»‘";
 var nv_creditcard = "Xin vui lĂ²ng nháº­p sá»‘ tháº» tĂ­n dá»¥ng há»£p lá»‡.";
 var nv_equalTo = "Xin vui lĂ²ng nháº­p cĂ¹ng má»™t giĂ¡ trá»‹ má»™t láº§n ná»¯a.";
 var nv_accept = "Xin vui lĂ²ng nháº­p giĂ¡ trá»‹ cĂ³ pháº§n má»Ÿ rá»™ng há»£p lá»‡.";
 var nv_maxlength = "Xin vui lĂ²ng nháº­p khĂ´ng quĂ¡ {0} kĂ½ tá»±.";
 var nv_minlength = "Xin vui lĂ²ng nháº­p Ă­t nháº¥t {0} kĂ½ tá»±.";
 var nv_rangelength = "Xin vui lĂ²ng nháº­p má»™t giĂ¡ trá»‹ giá»¯a {0} vĂ  {1} kĂ½ tá»±.";
 var nv_range = "Xin vui lĂ²ng nháº­p má»™t giĂ¡ trá»‹ giá»¯a {0} vĂ  {1}.";
 var nv_max = "Xin vui lĂ²ng nháº­p má»™t giĂ¡ trá»‹ nhá» hÆ¡n hoáº·c báº±ng {0}.";
 var nv_min = "Xin vui lĂ²ng nháº­p má»™t giĂ¡ trá»‹ lá»›n hÆ¡n hoáº·c báº±ng {0}.";
 
 // Contact
 var nv_fullname = "Há» tĂªn nháº­p khĂ´ng há»£p lá»‡.";
 var nv_title = "Báº¡n chÆ°a nháº­p tiĂªu Ä‘á».";
 var nv_content = "Ná»™i dung khĂ´ng Ä‘Æ°á»£c Ä‘á»ƒ trá»‘ng.";
 var nv_code = "MĂ£ báº£o máº­t khĂ´ng Ä‘Ăºng.";
 
 // Message before unload
 var nv_msgbeforeunload = "Dá»¯ liá»‡u chÆ°a Ä‘Æ°á»£c lÆ°u. Báº¡n sáº½ bá»‹ máº¥t dá»¯ liá»‡u náº¿u thoĂ¡t khá»i trang nĂ y. Báº¡n cĂ³ Ä‘á»“ng Ă½ thoĂ¡t khĂ´ng?";
 
 // ErrorMessage
 var NVJL = [];
 NVJL.errorRequest = "ÄĂ£ cĂ³ lá»—i xáº£y ra trong quĂ¡ trĂ¬nh truy váº¥n.";
 NVJL.errortimeout = "Thá»i gian chá» thá»±c thi yĂªu cáº§u Ä‘Ă£ quĂ¡ thá»i lÆ°á»£ng cho phĂ©p.";
 NVJL.errornotmodified = "TrĂ¬nh duyá»‡t nháº­n Ä‘Æ°á»£c thĂ´ng bĂ¡o vá» ná»™i dung táº­p tin khĂ´ng thay Ä‘á»•i, nhÆ°ng khĂ´ng tĂ¬m tháº¥y ná»™i dung lÆ°u trá»¯ tá»« bá»™ nhá»› Ä‘á»‡m.";
 NVJL.errorparseerror = "Äá»‹nh dáº¡ng XML/Json khĂ´ng há»£p lá»‡.";
 NVJL.error304 = "Ná»™i dung khĂ´ng Ä‘á»•i. TĂ i liá»‡u cĂ³ ná»™i dung giá»‘ng trong bá»™ nhá»› Ä‘á»‡m.";
 NVJL.error400 = "YĂªu cáº§u truy váº¥n khĂ´ng há»£p lá»‡.";
 NVJL.error401 = "Truy váº¥n bá»‹ tá»« chá»‘i.";
 NVJL.error403 = "YĂªu cáº§u bá»‹ Ä‘Ă¬nh chá»‰.";
 NVJL.error404 = "KhĂ´ng tĂ¬m tháº¥y táº­p tin yĂªu cáº§u. CĂ³ thá»ƒ do URL khĂ´ng há»£p lá»‡ hoáº·c táº­p tin khĂ´ng tá»“n táº¡i trĂªn mĂ¡y chá»§.";
 NVJL.error406 = "KhĂ´ng Ä‘Æ°á»£c cháº¥p nháº­n. TrĂ¬nh duyá»‡t khĂ´ng cháº¥p nháº­n kiá»ƒu MIME cá»§a táº­p tin Ä‘Æ°á»£c yĂªu cáº§u.";
 NVJL.error500 = "Lá»—i tá»« phĂ­a mĂ¡y chá»§ ná»™i bá»™.";
 NVJL.error502 = "Web server nháº­n Ä‘Æ°á»£c pháº£n há»“i khĂ´ng há»£p lá»‡ trong khi hoáº¡t Ä‘á»™ng nhÆ° má»™t gateway hoáº·c proxy. Báº¡n nháº­n Ä‘Æ°á»£c thĂ´ng bĂ¡o lá»—i khi cá»‘ gáº¯ng cháº¡y má»™t ká»‹ch báº£n CGI.";
 NVJL.error503 = "Dá»‹ch vá»¥ khĂ´ng kháº£ dá»¥ng.";
 