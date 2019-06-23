<template>
	<div>
		<div v-if="info">
			<h1>{{info.Name}}</h1>
			<div><strong>Рейтинг</strong>: {{info.Rating}}</div>
			<div><strong>Регион</strong>: {{info.Address.City.Region.Name}} (Средняя зарплата: {{info.Address.City.MeanIncome}} / средние расходы: {{info.Address.City.MeanExpenses }})</div>
			<p>{{info.Description}}</p>
		</div>
	</div>
</template>

<script>
	import axios from 'axios';

	export default {
		name: 'company',
		data() {
			return {
				info: null
			};
		},
		mounted() {
			axios
				.get('http://192.168.0.30:1488/api/companies/' + this.$route.params.id)
				.then(response => (this.info = response.data));
		}
	};
</script>
