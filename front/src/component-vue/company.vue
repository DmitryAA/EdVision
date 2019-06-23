<template>
	<div>
		<div v-if="info">
			<div><strong>Имя</strong>: {{info.Name}}</div>
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
