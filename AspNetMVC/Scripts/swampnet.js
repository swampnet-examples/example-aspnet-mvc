
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

	$("input[data-swampnet-autocomplete]").each(createAutocomplete);
});