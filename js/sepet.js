jQuery(document).ready(function () {

    /* jGrowl Notifications */
    //jQuery.jGrowl("Başarılı bir şekilde silindi !", { position: "bottom-right" });

    jQuery("#btnsepetekle").click(function () {


        jQuery("#drpurunler option:selected").each(function (i, selected) {

            if (StokKontrol(selected) == false) {

                return false;
            }

            jQuery("#drpsepet").append(jQuery(this).clone());

            jQuery(this).remove();

            var adet = parseInt(jQuery("#txtadet").val());
            var select = parseFloat(jQuery(selected).val());
            var toplam = select * adet;
            var txttoplam = jQuery("#txttoplam").val();

            if (adet >= 20) {
                toplam = fnIndirim(toplam, 25);
            }

            txttoplam = txttoplam.replace(',','.');
            
            var geneltoplam = parseFloat(txttoplam) + parseFloat(toplam);
            geneltoplam = geneltoplam.toFixed(2);


            var sTutar = geneltoplam.toString();
            sTutar = fnAddSeparatorsNF(sTutar, '.', ',', '.');

            jQuery("#txttoplam").val(sTutar);

            jQuery("#txtadet").val("1");

        });


        return false;

    });

    jQuery("#btnsepetcikar").click(function () {


        //var arr = $(this).attr("name").split("2");
        //var from = arr[0];
        //var to = arr[1];
        jQuery("#drpsepet option:selected").each(function (i, selected) {
            jQuery("#drpurunler").append($(this).clone());
            jQuery(this).remove();

            var adet = parseInt(jQuery(this).attr("rel"));
            select = parseFloat(jQuery(selected).val());
            txttoplam = jQuery("#txttoplam").val();
            toplam = select * adet;

            if (txttoplam != 0) {

                if (adet >= 20) {
                    toplam = fnIndirim(toplam, 25);
                }

                txttoplam = txttoplam.replace(',', '.');

                var geneltoplam = parseFloat(txttoplam) - parseFloat(toplam);
                geneltoplam = geneltoplam.toFixed(2);


                var sTutar = geneltoplam.toString();
                sTutar = fnAddSeparatorsNF(sTutar, '.', ',', '.');


                jQuery("#txttoplam").val(sTutar);
            }


        });


        return false;

    });

    jQuery('#txtadet').change(function () {
        jQuery("#drpurunler option:selected").each(function (i, selected) {

            if (StokKontrol(selected) == false) {

                return false;
            }

        });
    });

    jQuery("#btngonder").click(function () {

        //isterseniz burda ajax ile sayfaya postlayabilirsiniz
        var geneltoplam = jQuery("#txttoplam").val();

        alert(geneltoplam + " TL");

    });

});

function StokKontrol(selected) {
    var stoksayisi = jQuery(selected).attr("rev");
    var adet = jQuery('#txtadet').val();

    jQuery(selected).attr("rel", adet);


    if (parseInt(adet) > parseInt(stoksayisi)) {
        alert("Yeterli Sayıda Stok Yok");
        return false;
    }
}

function fnIndirim(tutar, indirimYuzde) {

    var inenMiktar = (tutar * indirimYuzde) / 100;
    var sonMiktar = tutar - inenMiktar;

    return sonMiktar;

}

function fnAddSeparatorsNF(nStr, inD, outD, sep) // Noktayı virgül yap ve fiyatlara uygun sayı formatı yap
{
    nStr += '';
    var dpos = nStr.indexOf(inD);
    var nStrEnd = '';
    if (dpos != -1) {
        nStrEnd = outD + nStr.substring(dpos + 1, nStr.length);
        nStr = nStr.substring(0, dpos);
    }
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(nStr)) {
        nStr = nStr.replace(rgx, '$1' + sep + '$2');
    }
    return nStr + nStrEnd;
}