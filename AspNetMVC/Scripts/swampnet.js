
$(function () {

	// 'Submit' when we select something from the autcomplete list
	var submitAutocompleteForm = function(event, ui){
		var $input = $(this);
		$input.val(ui.item.label);

		// grab first parent form
		var $form = $input.parents("form:first");

		// And submit
		$form.trigger("submit");
	};

	// Hook up jQuery autocomplete
	var createAutocomplete = function () {
		var $input = $(this);
		var options = {
			source: $input.attr("data-swampnet-autocomplete"),
			select: submitAutocompleteForm
		};
		$input.autocomplete(options);
	};


	var ajaxFormSubmit = function () {
		var $form = $(this);

		var options = {
			url: $form.attr("action"),
			type: $form.attr("method"),
			data: $form.serialize()
		};

		$.ajax(options).done(function (data) {
			// get target
			var $target = $($form.attr("data-swampnet-target"));

			$target.replaceWith(data);
		});

		// prevent browser from doing the default action (ie, submitting the form)
		return false;
	};

	$("form[data-swampnet-ajax='true']").submit(ajaxFormSubmit);
	$("input[data-swampnet-autocomplete]").each(createAutocomplete);
});