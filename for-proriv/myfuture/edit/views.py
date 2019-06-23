from django.shortcuts import render,render_to_response
from django.contrib import auth
from django.http import HttpResponseRedirect
from django.template.context_processors import csrf
from students.models import Students
from universites.models import Universities
from companies.models import Companies
from django.core.exceptions import ObjectDoesNotExist

def edit(request):
	try:
		persona = Students.objects.get(id_auth = request.user.id)
		name = persona.first_name + ' ' + persona.last_name + ' '+ persona.patronimic_name 
		type_object = 0
	except ObjectDoesNotExist:
		persona=None
	if persona != None:
		return render(request, 'edit/edit.html', {'name': name, 
			'type_object':type_object})
	else:
		try:
			persona = Universities.objects.get(id_auth = request.user.id)
			type_object = 1
		except ObjectDoesNotExist:
			persona=None
		if persona != None:
			return render(request, 'edit/edit.html', {'name': persona.name,
				'type_object':type_object})
		else:
			try:
				persona = Companies.objects.get(id_auth = request.user.id)
				type_object = 2
			except ObjectDoesNotExist:
				persona=None
			if persona != None:
				return render(request, 'edit/edit.html', {'name': persona.name, 
					'type_object':type_object})
			else:
				return HttpResponseRedirect("/")
				

